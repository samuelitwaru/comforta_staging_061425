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
   public class prc_authenticatereceptionist : GXProcedure
   {
      public prc_authenticatereceptionist( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_authenticatereceptionist( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_UserName ,
                           ref Guid aP1_LocationId ,
                           ref Guid aP2_OrganisationId )
      {
         this.AV10UserName = "" ;
         this.AV8LocationId = aP1_LocationId;
         this.AV9OrganisationId = aP2_OrganisationId;
         initialize();
         ExecuteImpl();
         aP0_UserName=this.AV10UserName;
         aP1_LocationId=this.AV8LocationId;
         aP2_OrganisationId=this.AV9OrganisationId;
      }

      public Guid executeUdp( out string aP0_UserName ,
                              ref Guid aP1_LocationId )
      {
         execute(out aP0_UserName, ref aP1_LocationId, ref aP2_OrganisationId);
         return AV9OrganisationId ;
      }

      public void executeSubmit( out string aP0_UserName ,
                                 ref Guid aP1_LocationId ,
                                 ref Guid aP2_OrganisationId )
      {
         this.AV10UserName = "" ;
         this.AV8LocationId = aP1_LocationId;
         this.AV9OrganisationId = aP2_OrganisationId;
         SubmitImpl();
         aP0_UserName=this.AV10UserName;
         aP1_LocationId=this.AV8LocationId;
         aP2_OrganisationId=this.AV9OrganisationId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_char1 = AV10UserName;
         new prc_getloggedinusername(context ).execute( out  GXt_char1) ;
         AV10UserName = GXt_char1;
         new prc_logtofile(context ).execute(  context.GetMessage( "UserName: ", "")+AV10UserName) ;
         /* Using cursor P00A32 */
         pr_default.execute(0, new Object[] {AV10UserName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A93ReceptionistEmail = P00A32_A93ReceptionistEmail[0];
            A29LocationId = P00A32_A29LocationId[0];
            A11OrganisationId = P00A32_A11OrganisationId[0];
            A89ReceptionistId = P00A32_A89ReceptionistId[0];
            AV8LocationId = A29LocationId;
            AV9OrganisationId = A11OrganisationId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         new prc_logtofile(context ).execute(  context.GetMessage( "Location: ", "")+AV8LocationId.ToString()) ;
         new prc_logtofile(context ).execute(  context.GetMessage( "Organisation: ", "")+AV9OrganisationId.ToString()) ;
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
         AV10UserName = "";
         GXt_char1 = "";
         P00A32_A93ReceptionistEmail = new string[] {""} ;
         P00A32_A29LocationId = new Guid[] {Guid.Empty} ;
         P00A32_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00A32_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         A93ReceptionistEmail = "";
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_authenticatereceptionist__default(),
            new Object[][] {
                new Object[] {
               P00A32_A93ReceptionistEmail, P00A32_A29LocationId, P00A32_A11OrganisationId, P00A32_A89ReceptionistId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string GXt_char1 ;
      private string AV10UserName ;
      private string A93ReceptionistEmail ;
      private Guid AV8LocationId ;
      private Guid AV9OrganisationId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A89ReceptionistId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Guid aP1_LocationId ;
      private Guid aP2_OrganisationId ;
      private IDataStoreProvider pr_default ;
      private string[] P00A32_A93ReceptionistEmail ;
      private Guid[] P00A32_A29LocationId ;
      private Guid[] P00A32_A11OrganisationId ;
      private Guid[] P00A32_A89ReceptionistId ;
      private string aP0_UserName ;
   }

   public class prc_authenticatereceptionist__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00A32;
          prmP00A32 = new Object[] {
          new ParDef("AV10UserName",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00A32", "SELECT ReceptionistEmail, LocationId, OrganisationId, ReceptionistId FROM Trn_Receptionist WHERE ReceptionistEmail = ( RTRIM(LTRIM(:AV10UserName))) ORDER BY ReceptionistId, OrganisationId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A32,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
       }
    }

 }

}
