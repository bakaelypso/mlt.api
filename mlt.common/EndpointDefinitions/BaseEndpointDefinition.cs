namespace mlt.common.EndpointDefinitions;

public abstract class BaseEndpointDefinition<TModel> : IEndpointDefinition
    where TModel : BaseModel
{
    private string ControllerPath => $"{GetControllerName}/";
    private const string GuidParam = "{{id:guid}}";
    protected virtual string GetControllerName => typeof(TModel).Name;
    private IEndpointRouteBuilder? _app;

    public virtual void DefineEndpoints(WebApplication app)
    {
        _app = app;

        MapGet(GetAll, "");
        MapGetById(GetById, "");
        MapPost(Create, "");
        MapPut(Update, "");
        MapDelete(DeleteById, "");

        WithEndpoints();
    }

    protected abstract void WithEndpoints();

    private string ToValidFormatRoute(string route)
        => !string.IsNullOrEmpty(route) && !route.EndsWith("/") ? $"{route}/" : route;

    protected void MapDelete(Func<IBaseRepository<TModel>, Guid, Task<IResult>> func, string route)
        => _app?.MapDelete($"/{ControllerPath}{ToValidFormatRoute(route)}{GuidParam}", func).WithTags(GetControllerName);

    protected void MapPut(Func<IBaseRepository<TModel>, Guid, TModel, Task<IResult>> func, string route)
        => _app?.MapPut($"/{ControllerPath}{ToValidFormatRoute(route)}{GuidParam}", func).WithTags(GetControllerName);

    protected void MapPost(Func<IBaseRepository<TModel>, TModel, Task<IResult>> func, string route)
        => _app?.MapPost($"/{ControllerPath}{ToValidFormatRoute(route)}", func).WithTags(GetControllerName);

    protected void MapGet<T>(Func<IBaseRepository<TModel>, Task<T>> func, string route)
        => _app?.MapGet($"/{ControllerPath}{ToValidFormatRoute(route)}", func).WithTags(GetControllerName);

    protected void MapGetById<T>(Func<IBaseRepository<TModel>, Guid, Task<T>> func, string route)
        => _app?.MapGet($"/{ControllerPath}{ToValidFormatRoute(route)}{GuidParam}", func).WithTags(GetControllerName);

    public abstract void DefineServices(IServiceCollection services);

    private static async Task<List<TModel>> GetAll(IBaseRepository<TModel> repo)
        => await repo.GetAsync();

    private static async Task<IResult> GetById(IBaseRepository<TModel> repo, Guid id)
    {
        var model = await repo.GetAsync(id);
        return model is not null ? Results.Ok(model) : Results.NotFound();
    }

    private async Task<IResult> Create(IBaseRepository<TModel> repo, TModel createdModel)
    {
        createdModel.CreatedDateTime = DateTime.UtcNow;
        await repo.CreateAsync(createdModel);
        return Results.Created($"/{ControllerPath}/{createdModel.Id}", createdModel);
    }

    private static async Task<IResult> Update(IBaseRepository<TModel> repo, Guid id, TModel updatedModel)
    {
        var baseModel = await repo.GetAsync(id);
        if (baseModel is null) return Results.NotFound();

        updatedModel.ModifiedDateTime = DateTime.UtcNow;
        await repo.UpdateAsync(id, updatedModel);
        return Results.Ok(updatedModel);
    }

    private static async Task<IResult> DeleteById(IBaseRepository<TModel> repo, Guid id)
    {
        await repo.RemoveAsync(id);
        return Results.Ok();
    }
}