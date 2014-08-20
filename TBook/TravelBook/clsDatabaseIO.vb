Imports Windows.Storage
Imports System.IO
Imports System.IO.IsolatedStorage
Imports System.Xml

Public Class clsDatabaseIO

 

    Public Shared Function ReadKML(tFilePath As String) As clsBook
        Dim _IsolatedStorage As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
        If _IsolatedStorage.FileExists(tFilePath) = False Then Return Nothing

        Dim _FS As IsolatedStorageFileStream = _IsolatedStorage.OpenFile(tFilePath, FileMode.Open, FileAccess.Read)
        Dim _Reader As XmlReader = XmlReader.Create(_FS)


        Dim _ResultBook As clsBook
        Dim _BookName As String = ""
        Dim _Description As String = ""
        Dim _StyleReaderList As New List(Of XmlReader)
        Dim _PleaseReaderList As New List(Of XmlReader)
        Dim _LayerList As New List(Of XmlReader)


        Dim _PlaceList As New List(Of clsPlace)
        Dim _StyleList As New List(Of clsPushPinStyle)


        While _Reader.Read()
            If _Reader.IsStartElement Then
                Select Case _Reader.Name.ToLower
                    Case "name"
                        _BookName = _Reader.ReadElementContentAsString
                    Case "description"
                        _Description = _Reader.ReadElementContentAsString
                    Case "style"
                        _StyleReaderList.Add(_Reader.ReadSubtree)
                        ' _Reader.ReadInnerXml()
                    Case "placemark"
                        Dim _tempReader As XmlReader = _Reader.ReadSubtree
                        _PleaseReaderList.Add(_tempReader)
                        _PlaceList.Add(New clsPlace(_tempReader))
                        _Reader.ReadInnerXml()
                    Case "folder"
                        _LayerList.Add(_Reader.ReadSubtree)
                        _Reader.ReadInnerXml()
                End Select
            End If
        End While 
         
        _ResultBook = New clsBook(_BookName, _Description, _StyleReaderList, _LayerList, _PleaseReaderList)

        
        _ResultBook._pLayerList.Item(0)._pPlaceList = _PlaceList

        _Reader.Dispose()
        _FS.Dispose()

        Return _ResultBook
    End Function
 
    Public Shared Sub CopyDefaultKMLToBookShelfFolder()
        Dim _AllKMLFilesinDefaultFolder As String() = Directory.GetFiles(clsGlobalVariables.gDefaultKMLFileFolder)

        Dim _IsoStore As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
        If _IsoStore.DirectoryExists(clsGlobalVariables.gBookShelfFileFolderName) = False Then
            _IsoStore.CreateDirectory(clsGlobalVariables.gBookShelfFileFolderName)
        End If

        For i As Integer = 0 To _AllKMLFilesinDefaultFolder.Length - 1
            Dim _DesFilePath As String = clsGlobalVariables.gBookShelfFileFolderName + _AllKMLFilesinDefaultFolder(i).Substring(_AllKMLFilesinDefaultFolder(i).Length - 8)
            CopyFileFromAssetsToIsoStorage(_AllKMLFilesinDefaultFolder(i), _DesFilePath)
        Next 
    End Sub

    Public Shared Sub CopyFileFromAssetsToIsoStorage(tOriginalFilePath As String, tDesFilePath As String)
        If File.Exists(tOriginalFilePath) = False Then Exit Sub
        Dim _OriginalUri As Uri = New Uri(tOriginalFilePath, UriKind.Relative)
        Dim _OriginalSRI As System.Windows.Resources.StreamResourceInfo = Application.GetResourceStream(_OriginalUri)
        Dim _OriginalData As IO.Stream = _OriginalSRI.Stream

        Dim _IsoStore As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
        If _IsoStore.FileExists(tDesFilePath) Then
            _IsoStore.DeleteFile(tDesFilePath)
        End If

        Dim _IsoStorage As IsolatedStorage.IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
        Dim _IsoStream As IsolatedStorageFileStream = _IsoStorage.CreateFile(tDesFilePath)
        _OriginalData.CopyTo(_IsoStream)

        _OriginalData.Dispose()
        _IsoStream.Dispose()
    End Sub
End Class
