using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace toptours1
{
    public class MyService
    {
        public static bool AddReview(string content, int rating, string caption, int customer_id, int route_id)
        {
            localhost.TopToursWS ws = new localhost.TopToursWS();
            return ws.AddReviewWS(content, rating, caption, customer_id, route_id);
        }
        public static localhost.Review GetReview(int customer_id,string caption)
        {
            localhost.TopToursWS ws = new localhost.TopToursWS();
            return ws.GetReviewWS(customer_id, caption);

        }
        public static void UpdateReview(localhost.Review r,string value,int num)
        {
            localhost.TopToursWS ws = new localhost.TopToursWS();
            ws.UpdateValueWS(r, value, num);
        }
        public static List<localhost.Review> GetAllReviews(int route_id)
        {
            localhost.TopToursWS ws = new localhost.TopToursWS();
            return ws.GetAllReviewsOfRouteWS(route_id).ToList();
        }
        public static void DeleteReview(localhost.Review r)
        {
            localhost.TopToursWS ws = new localhost.TopToursWS();
            ws.DeleteReviewWS(r);
        }





    }
}