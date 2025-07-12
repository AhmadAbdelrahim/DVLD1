﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD1
{
    public class clsUtilities
    {
        public static string GenerateGUID()
        {
            // Generate a new GUID
            Guid newGuid = Guid.NewGuid();

            // convert the GUID to a string
            return newGuid.ToString();
        }
        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            // Check if the folder exists
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(FolderPath);
                    return true; // Folder created successfully
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it as needed
                    MessageBox.Show($"Error creating folder: {ex.Message}");
                    return false;
                }
            }
            return true;
        }
        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            // Full file name. Change your file name
            string fileName = sourceFile;
            FileInfo fileInfo = new FileInfo(fileName);
            string exti = fileInfo.Extension;
            return GenerateGUID() + exti;
        }
        public static bool CopyImageToProjectFolderImages(ref string sourceFile)
        {
            // This funciton will copy the image to the project images foldr after renaming it
            // with GUID with the same extention, then it will update the sourceFileName with the new name.

            string destinationFolder = @"C:\DVDL1-Photos\";
            if (!CreateFolderIfDoesNotExist(destinationFolder))
                return false;

            string destinationFile = destinationFolder + ReplaceFileNameWithGUID(sourceFile);

            try
            {
                File.Copy(sourceFile, destinationFile, true); // true to overwrite if exists
            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            sourceFile = destinationFile; // Update the sourceFile with the new file name
            return true; // Return true if the copy was successful
        }
    }
}
