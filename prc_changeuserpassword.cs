using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
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
   public class prc_changeuserpassword : GXProcedure
   {
      public prc_changeuserpassword( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prc_changeuserpassword( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_userGUID ,
                           string aP1_password ,
                           string aP2_passwordNew ,
                           out string aP3_response )
      {
         this.AV2userGUID = aP0_userGUID;
         this.AV3password = aP1_password;
         this.AV4passwordNew = aP2_passwordNew;
         this.AV5response = "" ;
         initialize();
         ExecuteImpl();
         aP3_response=this.AV5response;
      }

      public string executeUdp( string aP0_userGUID ,
                                string aP1_password ,
                                string aP2_passwordNew )
      {
         execute(aP0_userGUID, aP1_password, aP2_passwordNew, out aP3_response);
         return AV5response ;
      }

      public void executeSubmit( string aP0_userGUID ,
                                 string aP1_password ,
                                 string aP2_passwordNew ,
                                 out string aP3_response )
      {
         this.AV2userGUID = aP0_userGUID;
         this.AV3password = aP1_password;
         this.AV4passwordNew = aP2_passwordNew;
         this.AV5response = "" ;
         SubmitImpl();
         aP3_response=this.AV5response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(string)AV2userGUID,(string)AV3password,(string)AV4passwordNew,(string)AV5response} ;
         ClassLoader.Execute("aprc_changeuserpassword","GeneXus.Programs","aprc_changeuserpassword", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 4 ) )
         {
            AV5response = (string)(args[3]) ;
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
      }

      public override void initialize( )
      {
         AV5response = "";
         /* GeneXus formulas. */
      }

      private string AV5response ;
      private string AV2userGUID ;
      private string AV3password ;
      private string AV4passwordNew ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private string aP3_response ;
   }

}
