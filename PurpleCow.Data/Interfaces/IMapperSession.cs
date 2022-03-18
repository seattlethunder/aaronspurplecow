using PurpleCow.Common.Models;

public interface IMapperSession
{
    void BeginTransaction();
    Task Commit();
    Task Rollback();
    void CloseTransaction();
    Task Save(Image entity);
    void Delete(Image entity);
    List<Image> GetImages();
    void SaveImage(Image entity);
    IQueryable<Image> Images { get; }
}