using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApi.Utils {
    public class CommonUtils {
        public static Dictionary<string,object> ReturnSuccess(object result) {
            Dictionary<string, object> res = new Dictionary<string, object>();
            res["success"] = true;
            res["data"] = result;
            return res;
        }

        public static Dictionary<string,object> FailedResponse(object result,HttpStatusCode code) {
            Dictionary<String, object> res = new Dictionary<String, object>();
            res["success"] = false;
            res["error"] = result;
            res["statusCode"] = code.ToString();
            return res;
        }
    }
}