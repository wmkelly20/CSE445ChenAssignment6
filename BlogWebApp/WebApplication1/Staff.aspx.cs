﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment6_2
{
    public partial class Staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }

    //public string GetImageUrl(string imageTitle)
    //{
    //    string xmlFilePath = Server.MapPath("~/ImageStorage.xml");

    //    if (!File.Exists(xmlFilePath)) return null;

    //    var doc = new System.Xml.XmlDocument();
    //    doc.Load(xmlFilePath);
    //    var node = doc.SelectSingleNode($"//Images/Image[Title='{imageTitle}']/Url");

    //    return node?.InnerText ?? null;
    //}

    //protected void UploadImage(object sender, EventArgs e)
    //{
    //    if (fileUpload.HasFile)
    //    {
    //        //var serviceClient = new ImageServiceClient();

    //        string imageName = $"{lblStaffName.Text.Replace(" ", "_").ToLower()}.png";
    //        byte[] imageData = fileUpload.FileBytes;
    //        string description = txtDescription.Text;

    //        //string result = serviceClient.UploadImage(imageName, imageData, description);
    //        //lblUploadStatus.Text = result;

    //        LoadStaffProfileImage(lblStaffName.Text);
    //    }
    //    else
    //    {
    //        lblUploadStatus.Text = "Please select an image to upload.";
    //    }
    //}


    //private void LoadStaffProfileImage(string staffName)
    //{
    //var serviceClient = new ImageServiceClient();
    // string imageTitle = $"{staffName} Profile Image"; // Match the title in the XML.

    //string imageUrl = serviceClient.GetImageUrl(imageTitle);
    //if (!string.IsNullOrEmpty(imageUrl))
    //{
    //    imgStaffProfile.ImageUrl = imageUrl;
    //}
    //else
    //{
    //    imgStaffProfile.ImageUrl = "images/default_profile.png"; // Fallback image.
    //}
    //}

    //protected void LogoutStaff(object sender, EventArgs e)
    //{
    //    Session.Clear();
    //    Response.Redirect("~/Login.aspx");
    //}


    //private bool ValidateStaffCredentials(string username, string password, out string role)
    //{
    //    role = null;

    //    // Example: Load staff credentials from XML
    //    var doc = new System.Xml.XmlDocument();
    //    doc.Load(Server.MapPath("~/Staff.xml"));

    //    var staffNode = doc.SelectSingleNode($"//Staff[Username='{username}' and Password='{password}']");
    //    if (staffNode != null)
    //    {
    //        role = staffNode["Role"]?.InnerText;
    //        return true;
    //    }

    //    return false;
    //}
}