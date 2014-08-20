Imports System.ComponentModel

Public Class vmMainMap
    Implements INotifyPropertyChanged


    Public Property pLayer As clsLayer
 

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
End Class
