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
   public class prc_getuseridfromaccesstoken : GXProcedure
   {
      public prc_getuseridfromaccesstoken( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getuseridfromaccesstoken( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_access_token ,
                           out string aP1_ResidentGUID ,
                           out bool aP2_IsValid )
      {
         this.AV8access_token = aP0_access_token;
         this.AV9ResidentGUID = "" ;
         this.AV10IsValid = false ;
         initialize();
         ExecuteImpl();
         aP1_ResidentGUID=this.AV9ResidentGUID;
         aP2_IsValid=this.AV10IsValid;
      }

      public bool executeUdp( string aP0_access_token ,
                              out string aP1_ResidentGUID )
      {
         execute(aP0_access_token, out aP1_ResidentGUID, out aP2_IsValid);
         return AV10IsValid ;
      }

      public void executeSubmit( string aP0_access_token ,
                                 out string aP1_ResidentGUID ,
                                 out bool aP2_IsValid )
      {
         this.AV8access_token = aP0_access_token;
         this.AV9ResidentGUID = "" ;
         this.AV10IsValid = false ;
         SubmitImpl();
         aP1_ResidentGUID=this.AV9ResidentGUID;
         aP2_IsValid=this.AV10IsValid;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10IsValid = false;
         AV9ResidentGUID = "";
         /* Using cursor P00972 */
         pr_gam.execute(0, new Object[] {AV8access_token});
         while ( (pr_gam.getStatus(0) != 101) )
         {
            A448sestoken = P00972_A448sestoken[0];
            A456userguid = P00972_A456userguid[0];
            A457sesdate = P00972_A457sesdate[0];
            A449repid = P00972_A449repid[0];
            AV9ResidentGUID = StringUtil.Trim( A456userguid);
            AV10IsValid = true;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_gam.readNext(0);
         }
         pr_gam.close(0);
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
         AV9ResidentGUID = "";
         P00972_A448sestoken = new string[] {""} ;
         P00972_A456userguid = new string[] {""} ;
         P00972_A457sesdate = new DateTime[] {DateTime.MinValue} ;
         P00972_A449repid = new int[1] ;
         A448sestoken = "";
         A456userguid = "";
         A457sesdate = (DateTime)(DateTime.MinValue);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_getuseridfromaccesstoken__gam(),
            new Object[][] {
                new Object[] {
               P00972_A448sestoken, P00972_A456userguid, P00972_A457sesdate, P00972_A449repid
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A449repid ;
      private string A448sestoken ;
      private string A456userguid ;
      private DateTime A457sesdate ;
      private bool AV10IsValid ;
      private string AV8access_token ;
      private string AV9ResidentGUID ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_gam ;
      private string[] P00972_A448sestoken ;
      private string[] P00972_A456userguid ;
      private DateTime[] P00972_A457sesdate ;
      private int[] P00972_A449repid ;
      private string aP1_ResidentGUID ;
      private bool aP2_IsValid ;
   }

   public class prc_getuseridfromaccesstoken__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00972;
          prmP00972 = new Object[] {
          new ParDef("AV8access_token",GXType.LongVarChar,2097152,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00972", "SELECT sestoken, userguid, sesdate, repid FROM gam.session WHERE sestoken = ( :AV8access_token) ORDER BY sesdate DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00972,1, GxCacheFrequency.OFF ,false,true )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((string[]) buf[0])[0] = rslt.getString(1, 120);
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

}
