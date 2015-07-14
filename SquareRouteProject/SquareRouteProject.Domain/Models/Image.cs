using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRouteProject.Domain.Models
{
  public class Image
    {

      public int ImageId { get; set; }
      public byte[] Data { get; set; }
      public string ContentType { get; set; }
      public int ContentLength { get; set; }
      public string FileName { get; set; }
      public string File
      {
          get
          {
              string mimeType = "image/png";
              string base64 = Convert.ToBase64String(Data);
              return string.Format("data:{0},{1}", mimeType, base64);
          }
      }
      [ForeignKey("User")]
      public string UserId { get; set; }
      public virtual ApplicationUser User { get; set; }
      public bool TermsAgreementandLoading { get; set; }
      


      public Image()
      {

          ImageId = 0;
          FileName = " New File";
          Data = new byte[] { };
          ContentType = "";
          ContentLength = 0;
      }

       
    }

}
