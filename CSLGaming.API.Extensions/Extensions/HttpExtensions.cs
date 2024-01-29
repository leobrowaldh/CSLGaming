namespace CSLGaming.API.Extensions
{
    public static class HttpExtensions
    {
        public static void AddEndpoint<TEntity, TPostDto, TPutDto, TGetDto>(this WebApplication app)
        where TEntity : class, IEntity where TPostDto : class where TPutDto : class where TGetDto : class
        {
            var node = typeof(TEntity).Name.ToLower();
            //app.MapGet($"/api/{node}s/" + "{id}", HttpSingleAsync<TEntity, TGetDto>);
            app.MapGet($"/api/{node}s", HttpGetAsync<TEntity, TGetDto>);
            //app.MapPost($"/api/{node}s", HttpPostAsync<TEntity, TPostDto>);
            //app.MapPut($"/api/{node}s/" + "{id}", HttpPutAsync<TEntity, TPutDto>);
            //app.MapDelete($"/api/{node}s/" + "{id}", HttpDeleteAsync<TEntity>);
        }

        public static async Task<IResult> HttpGetAsync<TEntity, TDto>()
        where TEntity : class where TDto : class =>
        Results.Ok();

        // "await db.GetAsync<TEntity, TDto>()" - ska vara mellan ok()

        // "this IDbService db" - ska vara i "()" efter TDto på rad 16
    }
}
