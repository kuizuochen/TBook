Imports System.ComponentModel
Imports System.Collections.ObjectModel

Public Class vmMain
    Implements INotifyPropertyChanged

    Public Property pMainMap As vmMainMap
    Public Property pMainList As vmMainList

    Public Property pPlaceList As ObservableCollection(Of clsPlace)

    Public Sub New(tBook As clsBook)
        pMainList = New vmMainList(tBook._pLayerList.Item(0))


        pPlaceList = New ObservableCollection(Of clsPlace)
        Dim tempPlace As clsPlace = New clsPlace
        tempPlace.pName = "test1"
        pPlaceList.Add(tempPlace)


        Dim tempPlace2 As clsPlace = New clsPlace
        tempPlace2.pName = "test2"
        pPlaceList.Add(tempPlace2)
    End Sub

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
End Class
