using demo.Areas.Error;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace demo.Services
{
    public static class Helper
    {
        public static object handleDBNull(this object foValue)
        {
            if (foValue == null)
            {
                return DBNull.Value;
            }
            return foValue;
        }
            public static string getSql(this string foStoreProcedureName, List<SqlParameter> foParameters = null)
            {
                string lsSPParameter = string.Empty;
                List<ErrorTrackingModel> laErrorTrackingModels = new List<ErrorTrackingModel>();
                ErrorTrackingModel laErrorTrackingModel = new ErrorTrackingModel();

                laErrorTrackingModel.stStoredProcedureName = foStoreProcedureName;

                if (foParameters != null)
                {
                    for (int liIndex = 0; liIndex < foParameters.Count; liIndex++)
                    {

                        laErrorTrackingModel.gaParameterNameValuePair.Add(foParameters[liIndex].ParameterName.ToString(), foParameters[liIndex].Value == null ? "" : Convert.ToString(foParameters[liIndex].Value));

                        if (liIndex > 0)
                        {
                            lsSPParameter += ", @" + foParameters[liIndex].ParameterName; ;
                        }
                        else
                        {
                            lsSPParameter += " @" + foParameters[liIndex].ParameterName;
                        }
                        if (foParameters[liIndex].Direction == System.Data.ParameterDirection.Output)
                        {
                            lsSPParameter += " OUT ";
                        }
                    }
                }

               

                return "EXEC [" + foStoreProcedureName + "]" + lsSPParameter;
            }



        }
    }
