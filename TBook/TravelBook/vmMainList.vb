Imports System.ComponentModel
Imports System.Collections.ObjectModel

Public Class vmMainList
    Implements INotifyPropertyChanged

    Public Property pPlaceList As ObservableCollection(Of clsPlace)

    Public Sub New(tLayer As clsLayer)
        pPlaceList = New ObservableCollection(Of clsPlace)

        For i As Integer = 0 To tLayer._pPlaceList.Count - 1
            _pPlaceList.Add(tLayer._pPlaceList.Item(i))
        Next

        'Dim tempPlace As clsPlace = New clsPlace
        'tempPlace.pName = "test1"
        'pPlaceList.Add(tempPlace)
    End Sub

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
End Class
