namespace application.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";

    public string email { get; set; } = "alexmosin@inbox.ru";

    private readonly Data _data;

    public MainWindowViewModel(Data data)
    {
        _data = data;
    }


    public string MyData
    {
        get => _data.MyData;
        set => _data.MyData = value;
    }

    public bool CheckExistance() {
        return _data.CheckExistance("alexmosin@inbox.ru");
    }

    public string str //= CheckExistance().ToString();
    {
        get => _data.CheckExistance("alexmosin@inbox.ru").ToString();
    }
}
