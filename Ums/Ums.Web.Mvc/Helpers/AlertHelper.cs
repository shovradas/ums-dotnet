using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ums.Web.Mvc.Helpers
{
    public class AlertHelper
    {
        public static String SuccessAlert(String status, String message)
        {
            return $"<div class='alert alert-success alert-dismissible'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>{status}!</strong> {message}</div>";
        }

        public static String InfoAlert(String status, String message)
        {
            return $"<div class='alert alert-info alert-dismissible'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>{status}!</strong > {message}</div>";
        }

        public static String WarningAlert(String status, String message)
        {
            return $"<div class='alert alert-warning alert-dismissible'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>{status}!</strong> {message}</div>";
        }

        public static String DangerAlert(String status, String message)
        {
            return $"<div class='alert alert-danger alert-dismissible'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>{status}!</strong> {message}</div>";
        }
    }
}