namespace Regional.DTO;


public interface IAddDto<out T> where T : class {
    T? Map();
}

public interface IUpdateDto<in T> where T : class {
    void Map(T entity);
}