using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FeaturesDemo.ViewModels
{
    public class TakePicturePageViewModel:ViewModel
    {
        private string imgSource;

        public string ImgSource { get => imgSource; set { imgSource = value; OnPropertyChanged(); } }
        public ICommand ChooseFileCommand { get;private set; }  
        public ICommand CapturePhotoCommand { get;private set; }

        public ICommand OpenFileCommand { get; private set; }

        public TakePicturePageViewModel() {
            ChooseFileCommand = new Command(ChoosePhoto);
            CapturePhotoCommand = new Command(CapturePhoto);
            OpenFileCommand = new Command(OpenFile);
            
        }

        private async void OpenFile()
        {
            //סוגי קבצים להצגה
            PickOptions options=new PickOptions();
            options.FileTypes = FilePickerFileType.Pdf;
            options.PickerTitle = "בחר קובץ";
            try
            {
                var result = await FilePicker.Default.PickAsync(options);
                if (result != null)
                {
                 await Launcher.Default.OpenAsync(new OpenFileRequest("קובץ לקריאה", new ReadOnlyFile(result.FullPath)));
                }

               
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
            }

            




        }

        private async void CapturePhoto()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
                if (photo != null)
                {
                    // save the file into local storage
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                    //The FullPath property doesn't always return the physical path to the file. To get the file, use the OpenReadAsync method.
                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);

                    await sourceStream.CopyToAsync(localFileStream);
                    ImgSource = localFilePath;
                }
            }
        }

        private async void ChoosePhoto()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.PickPhotoAsync();
                if (photo != null)
                {
                    ImgSource = photo.FullPath;
                }
            }



        }
    }
}
