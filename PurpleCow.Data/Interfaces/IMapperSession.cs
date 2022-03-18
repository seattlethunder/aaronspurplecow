using PurpleCow.Common.Models;

public interface IMapperSession
{
    void BeginTransaction();
    Task Commit();
    Task Rollback();
    void CloseTransaction();
    Task Save(Image entity);
    Task Delete(Image entity);
    List<Image> GetImages();
    IQueryable<Image> Images { get; }
}