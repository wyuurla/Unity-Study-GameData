/**
 * @brief IObserver
 * @detail 상태 변화가 있을 때마다 옵저버에게 통지하도록 하는 행동패턴.
 * @date 2024-01-30
 * @version 1.0.0
 * @author kij
 */
public interface IObserver
{
    void Notify(Subject _subject);
}
