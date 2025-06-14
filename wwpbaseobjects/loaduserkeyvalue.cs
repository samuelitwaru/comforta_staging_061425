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
namespace GeneXus.Programs.wwpbaseobjects {
   public class loaduserkeyvalue : GXProcedure
   {
      public loaduserkeyvalue( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loaduserkeyvalue( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_UserCustomizationsKey ,
                           out string aP1_UserCustomizationsValue )
      {
         this.AV25UserCustomizationsKey = aP0_UserCustomizationsKey;
         this.AV26UserCustomizationsValue = "" ;
         initialize();
         ExecuteImpl();
         aP1_UserCustomizationsValue=this.AV26UserCustomizationsValue;
      }

      public string executeUdp( string aP0_UserCustomizationsKey )
      {
         execute(aP0_UserCustomizationsKey, out aP1_UserCustomizationsValue);
         return AV26UserCustomizationsValue ;
      }

      public void executeSubmit( string aP0_UserCustomizationsKey ,
                                 out string aP1_UserCustomizationsValue )
      {
         this.AV25UserCustomizationsKey = aP0_UserCustomizationsKey;
         this.AV26UserCustomizationsValue = "" ;
         SubmitImpl();
         aP1_UserCustomizationsValue=this.AV26UserCustomizationsValue;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV26UserCustomizationsValue = AV24Session.Get(AV25UserCustomizationsKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26UserCustomizationsValue)) )
         {
            AV28UserCustomizations.Load(new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid(), AV25UserCustomizationsKey);
            if ( AV28UserCustomizations.Success() )
            {
               AV26UserCustomizationsValue = AV28UserCustomizations.gxTpr_Usercustomizationsvalue;
            }
            else
            {
               AV26UserCustomizationsValue = "";
            }
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
         AV26UserCustomizationsValue = "";
         AV24Session = context.GetSession();
         AV28UserCustomizations = new GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations(context);
         /* GeneXus formulas. */
      }

      private string AV26UserCustomizationsValue ;
      private string AV25UserCustomizationsKey ;
      private IGxSession AV24Session ;
      private GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations AV28UserCustomizations ;
      private string aP1_UserCustomizationsValue ;
   }

}
