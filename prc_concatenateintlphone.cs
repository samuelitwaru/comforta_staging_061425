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
   public class prc_concatenateintlphone : GXProcedure
   {
      public prc_concatenateintlphone( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_concatenateintlphone( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_PhoneCode ,
                           string aP1_PhoneNumber ,
                           out string aP2_IntlPhone )
      {
         this.AV9PhoneCode = aP0_PhoneCode;
         this.AV10PhoneNumber = aP1_PhoneNumber;
         this.AV8IntlPhone = "" ;
         initialize();
         ExecuteImpl();
         aP2_IntlPhone=this.AV8IntlPhone;
      }

      public string executeUdp( string aP0_PhoneCode ,
                                string aP1_PhoneNumber )
      {
         execute(aP0_PhoneCode, aP1_PhoneNumber, out aP2_IntlPhone);
         return AV8IntlPhone ;
      }

      public void executeSubmit( string aP0_PhoneCode ,
                                 string aP1_PhoneNumber ,
                                 out string aP2_IntlPhone )
      {
         this.AV9PhoneCode = aP0_PhoneCode;
         this.AV10PhoneNumber = aP1_PhoneNumber;
         this.AV8IntlPhone = "" ;
         SubmitImpl();
         aP2_IntlPhone=this.AV8IntlPhone;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8IntlPhone = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10PhoneNumber)) )
         {
            AV8IntlPhone = AV9PhoneCode + "" + AV10PhoneNumber;
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
         AV8IntlPhone = "";
         /* GeneXus formulas. */
      }

      private string AV8IntlPhone ;
      private string AV9PhoneCode ;
      private string AV10PhoneNumber ;
      private string aP2_IntlPhone ;
   }

}
