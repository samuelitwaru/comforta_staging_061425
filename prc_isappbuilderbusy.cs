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
   public class prc_isappbuilderbusy : GXProcedure
   {
      public prc_isappbuilderbusy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_isappbuilderbusy( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out bool aP0_IsBusy )
      {
         this.AV8IsBusy = false ;
         initialize();
         ExecuteImpl();
         aP0_IsBusy=this.AV8IsBusy;
      }

      public bool executeUdp( )
      {
         execute(out aP0_IsBusy);
         return AV8IsBusy ;
      }

      public void executeSubmit( out bool aP0_IsBusy )
      {
         this.AV8IsBusy = false ;
         SubmitImpl();
         aP0_IsBusy=this.AV8IsBusy;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8IsBusy = false;
         GXt_char1 = AV9UserId;
         new prc_getloggedinuserid(context ).execute( out  GXt_char1) ;
         AV9UserId = GXt_char1;
         /* Using cursor P00GE2 */
         pr_default.execute(0, new Object[] {AV9UserId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P00GE2_A11OrganisationId[0];
            A29LocationId = P00GE2_A29LocationId[0];
            A89ReceptionistId = P00GE2_A89ReceptionistId[0];
            A630ToolBoxLastUpdateReceptionistI = P00GE2_A630ToolBoxLastUpdateReceptionistI[0];
            n630ToolBoxLastUpdateReceptionistI = P00GE2_n630ToolBoxLastUpdateReceptionistI[0];
            A631ToolBoxLastUpdateTime = P00GE2_A631ToolBoxLastUpdateTime[0];
            n631ToolBoxLastUpdateTime = P00GE2_n631ToolBoxLastUpdateTime[0];
            A95ReceptionistGAMGUID = P00GE2_A95ReceptionistGAMGUID[0];
            A630ToolBoxLastUpdateReceptionistI = P00GE2_A630ToolBoxLastUpdateReceptionistI[0];
            n630ToolBoxLastUpdateReceptionistI = P00GE2_n630ToolBoxLastUpdateReceptionistI[0];
            A631ToolBoxLastUpdateTime = P00GE2_A631ToolBoxLastUpdateTime[0];
            n631ToolBoxLastUpdateTime = P00GE2_n631ToolBoxLastUpdateTime[0];
            /* Using cursor P00GE3 */
            pr_default.execute(1, new Object[] {A29LocationId, A11OrganisationId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               if ( P00GE2_n630ToolBoxLastUpdateReceptionistI[0] || ( ( A630ToolBoxLastUpdateReceptionistI == A89ReceptionistId ) ) )
               {
                  AV8IsBusy = false;
               }
               else
               {
                  AV10ServerTime = DateTimeUtil.ResetDate(DateTimeUtil.ServerNow( context, pr_default));
                  AV11Diff = (long)(DateTimeUtil.TDiff( AV10ServerTime, A631ToolBoxLastUpdateTime));
                  if ( AV11Diff >= 1800 )
                  {
                     AV8IsBusy = false;
                  }
                  else
                  {
                     AV8IsBusy = true;
                  }
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV9UserId = "";
         GXt_char1 = "";
         P00GE2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00GE2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00GE2_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         P00GE2_A630ToolBoxLastUpdateReceptionistI = new Guid[] {Guid.Empty} ;
         P00GE2_n630ToolBoxLastUpdateReceptionistI = new bool[] {false} ;
         P00GE2_A631ToolBoxLastUpdateTime = new DateTime[] {DateTime.MinValue} ;
         P00GE2_n631ToolBoxLastUpdateTime = new bool[] {false} ;
         P00GE2_A95ReceptionistGAMGUID = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         A630ToolBoxLastUpdateReceptionistI = Guid.Empty;
         A631ToolBoxLastUpdateTime = (DateTime)(DateTime.MinValue);
         A95ReceptionistGAMGUID = "";
         P00GE3_A29LocationId = new Guid[] {Guid.Empty} ;
         P00GE3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         AV10ServerTime = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_isappbuilderbusy__default(),
            new Object[][] {
                new Object[] {
               P00GE2_A11OrganisationId, P00GE2_A29LocationId, P00GE2_A89ReceptionistId, P00GE2_A630ToolBoxLastUpdateReceptionistI, P00GE2_n630ToolBoxLastUpdateReceptionistI, P00GE2_A631ToolBoxLastUpdateTime, P00GE2_n631ToolBoxLastUpdateTime, P00GE2_A95ReceptionistGAMGUID
               }
               , new Object[] {
               P00GE3_A29LocationId, P00GE3_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV11Diff ;
      private string GXt_char1 ;
      private DateTime A631ToolBoxLastUpdateTime ;
      private DateTime AV10ServerTime ;
      private bool AV8IsBusy ;
      private bool n630ToolBoxLastUpdateReceptionistI ;
      private bool n631ToolBoxLastUpdateTime ;
      private string AV9UserId ;
      private string A95ReceptionistGAMGUID ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A89ReceptionistId ;
      private Guid A630ToolBoxLastUpdateReceptionistI ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00GE2_A11OrganisationId ;
      private Guid[] P00GE2_A29LocationId ;
      private Guid[] P00GE2_A89ReceptionistId ;
      private Guid[] P00GE2_A630ToolBoxLastUpdateReceptionistI ;
      private bool[] P00GE2_n630ToolBoxLastUpdateReceptionistI ;
      private DateTime[] P00GE2_A631ToolBoxLastUpdateTime ;
      private bool[] P00GE2_n631ToolBoxLastUpdateTime ;
      private string[] P00GE2_A95ReceptionistGAMGUID ;
      private Guid[] P00GE3_A29LocationId ;
      private Guid[] P00GE3_A11OrganisationId ;
      private bool aP0_IsBusy ;
   }

   public class prc_isappbuilderbusy__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00GE2;
          prmP00GE2 = new Object[] {
          new ParDef("AV9UserId",GXType.VarChar,100,0)
          };
          Object[] prmP00GE3;
          prmP00GE3 = new Object[] {
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GE2", "SELECT T1.OrganisationId, T1.LocationId, T1.ReceptionistId, T2.ToolBoxLastUpdateReceptionistI, T2.ToolBoxLastUpdateTime, T1.ReceptionistGAMGUID FROM (Trn_Receptionist T1 INNER JOIN Trn_Location T2 ON T2.LocationId = T1.LocationId AND T2.OrganisationId = T1.OrganisationId) WHERE T1.ReceptionistGAMGUID = ( :AV9UserId) ORDER BY T1.ReceptionistId, T1.OrganisationId, T1.LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GE2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GE3", "SELECT LocationId, OrganisationId FROM Trn_Location WHERE LocationId = :LocationId and OrganisationId = :OrganisationId ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GE3,1, GxCacheFrequency.OFF ,true,true )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
       }
    }

 }

}
