namespace Api.DTO;

public interface IAddDto<T> where T : class {
    T? Map();
}

public interface IUpdateDto<T> where T : class {
    void Map(T entity);
}
 