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
        Dim tempReader As XmlReader

        While _Reader.Read()
            If _Reader.IsStartElement Then
                If _Reader.Name = "Placemark" Then


                    Dim a As String = _Reader.Name

                    tempReader = _Reader.ReadSubtree()
                    Exit While
                End If
            End If
        End While

        While tempReader.Read()
            If tempReader.IsStartElement Then 


                Dim a As String = tempReader.Name
                    'a = _Reader.Name
                Dim k As Integer = 109
            End If

        End While

        _Reader.Dispose()
        _FS.Dispose()

        Return Nothing
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
