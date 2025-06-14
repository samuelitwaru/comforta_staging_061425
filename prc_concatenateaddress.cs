using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prc_concatenateaddress : GXProcedure
   {
      public prc_concatenateaddress( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_concatenateaddress( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Country ,
                           string aP1_City ,
                           string aP2_ZipCode ,
                           string aP3_AddressLine1 ,
                           string aP4_AddressLine2 ,
                           out string aP5_Address )
      {
         this.AV12Country = aP0_Country;
         this.AV11City = aP1_City;
         this.AV13ZipCode = aP2_ZipCode;
         this.AV9AddressLine1 = aP3_AddressLine1;
         this.AV10AddressLine2 = aP4_AddressLine2;
         this.AV8Address = "" ;
         initialize();
         ExecuteImpl();
         aP5_Address=this.AV8Address;
      }

      public string executeUdp( string aP0_Country ,
                                string aP1_City ,
                                string aP2_ZipCode ,
                                string aP3_AddressLine1 ,
                                string aP4_AddressLine2 )
      {
         execute(aP0_Country, aP1_City, aP2_ZipCode, aP3_AddressLine1, aP4_AddressLine2, out aP5_Address);
         return AV8Address ;
      }

      public void executeSubmit( string aP0_Country ,
                                 string aP1_City ,
                                 string aP2_ZipCode ,
                                 string aP3_AddressLine1 ,
                                 string aP4_AddressLine2 ,
                                 out string aP5_Address )
      {
         this.AV12Country = aP0_Country;
         this.AV11City = aP1_City;
         this.AV13ZipCode = aP2_ZipCode;
         this.AV9AddressLine1 = aP3_AddressLine1;
         this.AV10AddressLine2 = aP4_AddressLine2;
         this.AV8Address = "" ;
         SubmitImpl();
         aP5_Address=this.AV8Address;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Address = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10AddressLine2)) )
         {
            AV8Address += AV10AddressLine2 + ", ";
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9AddressLine1)) )
         {
            AV8Address += AV9AddressLine1 + ", ";
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13ZipCode)) )
         {
            AV8Address += AV13ZipCode + " ";
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11City)) )
         {
            AV8Address += AV11City + ", ";
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12Country)) )
         {
            AV8Address += AV12Country;
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV8Address = "";
         /* GeneXus formulas. */
      }

      private string AV12Country ;
      private string AV11City ;
      private string AV13ZipCode ;
      private string AV9AddressLine1 ;
      private string AV10AddressLine2 ;
      private string AV8Address ;
      private string aP5_Address ;
   }

}
