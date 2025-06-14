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
   public class prc_getdefaultresidentpackage : GXProcedure
   {
      public prc_getdefaultresidentpackage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getdefaultresidentpackage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId ,
                           out Guid aP1_ResidentPackageId ,
                           out string aP2_ResidentPackageName ,
                           out bool aP3_NoDefault )
      {
         this.AV9LocationId = aP0_LocationId;
         this.AV10ResidentPackageId = Guid.Empty ;
         this.AV11ResidentPackageName = "" ;
         this.AV12NoDefault = false ;
         initialize();
         ExecuteImpl();
         aP1_ResidentPackageId=this.AV10ResidentPackageId;
         aP2_ResidentPackageName=this.AV11ResidentPackageName;
         aP3_NoDefault=this.AV12NoDefault;
      }

      public bool executeUdp( Guid aP0_LocationId ,
                              out Guid aP1_ResidentPackageId ,
                              out string aP2_ResidentPackageName )
      {
         execute(aP0_LocationId, out aP1_ResidentPackageId, out aP2_ResidentPackageName, out aP3_NoDefault);
         return AV12NoDefault ;
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 out Guid aP1_ResidentPackageId ,
                                 out string aP2_ResidentPackageName ,
                                 out bool aP3_NoDefault )
      {
         this.AV9LocationId = aP0_LocationId;
         this.AV10ResidentPackageId = Guid.Empty ;
         this.AV11ResidentPackageName = "" ;
         this.AV12NoDefault = false ;
         SubmitImpl();
         aP1_ResidentPackageId=this.AV10ResidentPackageId;
         aP2_ResidentPackageName=this.AV11ResidentPackageName;
         aP3_NoDefault=this.AV12NoDefault;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12NoDefault = false;
         AV13GXLvl2 = 0;
         /* Using cursor P00B32 */
         pr_default.execute(0, new Object[] {AV9LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A533ResidentPackageDefault = P00B32_A533ResidentPackageDefault[0];
            A528SG_LocationId = P00B32_A528SG_LocationId[0];
            A527ResidentPackageId = P00B32_A527ResidentPackageId[0];
            A531ResidentPackageName = P00B32_A531ResidentPackageName[0];
            AV13GXLvl2 = 1;
            AV10ResidentPackageId = A527ResidentPackageId;
            AV11ResidentPackageName = A531ResidentPackageName;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV13GXLvl2 == 0 )
         {
            AV12NoDefault = true;
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
         AV10ResidentPackageId = Guid.Empty;
         AV11ResidentPackageName = "";
         P00B32_A533ResidentPackageDefault = new bool[] {false} ;
         P00B32_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         P00B32_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         P00B32_A531ResidentPackageName = new string[] {""} ;
         A528SG_LocationId = Guid.Empty;
         A527ResidentPackageId = Guid.Empty;
         A531ResidentPackageName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getdefaultresidentpackage__default(),
            new Object[][] {
                new Object[] {
               P00B32_A533ResidentPackageDefault, P00B32_A528SG_LocationId, P00B32_A527ResidentPackageId, P00B32_A531ResidentPackageName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13GXLvl2 ;
      private bool AV12NoDefault ;
      private bool A533ResidentPackageDefault ;
      private string AV11ResidentPackageName ;
      private string A531ResidentPackageName ;
      private Guid AV9LocationId ;
      private Guid AV10ResidentPackageId ;
      private Guid A528SG_LocationId ;
      private Guid A527ResidentPackageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] P00B32_A533ResidentPackageDefault ;
      private Guid[] P00B32_A528SG_LocationId ;
      private Guid[] P00B32_A527ResidentPackageId ;
      private string[] P00B32_A531ResidentPackageName ;
      private Guid aP1_ResidentPackageId ;
      private string aP2_ResidentPackageName ;
      private bool aP3_NoDefault ;
   }

   public class prc_getdefaultresidentpackage__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00B32;
          prmP00B32 = new Object[] {
          new ParDef("AV9LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B32", "SELECT ResidentPackageDefault, SG_LocationId, ResidentPackageId, ResidentPackageName FROM Trn_ResidentPackage WHERE (SG_LocationId = :AV9LocationId) AND (ResidentPackageDefault = TRUE) ORDER BY SG_LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B32,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
