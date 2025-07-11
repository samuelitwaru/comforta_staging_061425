using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class reorg : GXReorganization
   {
      public reorg( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public reorg( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         if ( PreviousCheck() )
         {
            ExecuteReorganization( ) ;
         }
      }

      private void FirstActions( )
      {
         /* Load data into tables. */
      }

      public void ReorganizeTrn_Manager( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_Manager */
         cmdBuffer=" ALTER TABLE Trn_Manager ADD ManagerTitle VARCHAR(100)  "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      public void ReorganizeTrn_SupplierGen( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_SupplierGen */
         cmdBuffer=" ALTER TABLE Trn_SupplierGen ADD SupplierGenContactTitle VARCHAR(100)  "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      public void ReorganizeTrn_NetworkIndividual( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_NetworkIndividual */
         cmdBuffer=" ALTER TABLE Trn_NetworkIndividual ADD NetworkIndividualTitle VARCHAR(100)  "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      public void ReorganizeTrn_Receptionist( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_Receptionist */
         cmdBuffer=" ALTER TABLE Trn_Receptionist ADD ReceptionistTitle VARCHAR(100)  "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      public void ReorganizeTrn_Resident( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_Resident */
         cmdBuffer=" ALTER TABLE Trn_Resident ADD ResidentTitle VARCHAR(100) , ADD ResidentGroups TEXT  "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" ALTER TABLE Trn_Resident ALTER COLUMN ResidentSalutation DROP NOT NULL "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      private void TablesCount( )
      {
         if ( ! IsResumeMode( ) )
         {
            /* Using cursor P00012 */
            pr_default.execute(0);
            Trn_ManagerCount = P00012_ATrn_ManagerCount[0];
            pr_default.close(0);
            PrintRecordCount ( "Trn_Manager" ,  Trn_ManagerCount );
            /* Using cursor P00023 */
            pr_default.execute(1);
            Trn_SupplierGenCount = P00023_ATrn_SupplierGenCount[0];
            pr_default.close(1);
            PrintRecordCount ( "Trn_SupplierGen" ,  Trn_SupplierGenCount );
            /* Using cursor P00034 */
            pr_default.execute(2);
            Trn_NetworkIndividualCount = P00034_ATrn_NetworkIndividualCount[0];
            pr_default.close(2);
            PrintRecordCount ( "Trn_NetworkIndividual" ,  Trn_NetworkIndividualCount );
            /* Using cursor P00045 */
            pr_default.execute(3);
            Trn_ReceptionistCount = P00045_ATrn_ReceptionistCount[0];
            pr_default.close(3);
            PrintRecordCount ( "Trn_Receptionist" ,  Trn_ReceptionistCount );
            /* Using cursor P00056 */
            pr_default.execute(4);
            Trn_ResidentCount = P00056_ATrn_ResidentCount[0];
            pr_default.close(4);
            PrintRecordCount ( "Trn_Resident" ,  Trn_ResidentCount );
         }
      }

      private bool PreviousCheck( )
      {
         if ( ! MustRunCheck( ) )
         {
            return true ;
         }
         sSchemaVar = GXUtil.UserId( "Server", context, pr_default);
         if ( ColumnExist("Trn_Manager",sSchemaVar,"ManagerTitle") )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_column_exist", new   object[]  {"ManagerTitle", "Trn_Manager"}) ) ;
            return false ;
         }
         if ( ColumnExist("Trn_SupplierGen",sSchemaVar,"SupplierGenContactTitle") )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_column_exist", new   object[]  {"SupplierGenContactTitle", "Trn_SupplierGen"}) ) ;
            return false ;
         }
         if ( ColumnExist("Trn_NetworkIndividual",sSchemaVar,"NetworkIndividualTitle") )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_column_exist", new   object[]  {"NetworkIndividualTitle", "Trn_NetworkIndividual"}) ) ;
            return false ;
         }
         if ( ColumnExist("Trn_Receptionist",sSchemaVar,"ReceptionistTitle") )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_column_exist", new   object[]  {"ReceptionistTitle", "Trn_Receptionist"}) ) ;
            return false ;
         }
         if ( ColumnExist("Trn_Resident",sSchemaVar,"ResidentTitle") )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_column_exist", new   object[]  {"ResidentTitle", "Trn_Resident"}) ) ;
            return false ;
         }
         if ( ColumnExist("Trn_Resident",sSchemaVar,"ResidentGroups") )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_column_exist", new   object[]  {"ResidentGroups", "Trn_Resident"}) ) ;
            return false ;
         }
         return true ;
      }

      private bool ColumnExist( string sTableName ,
                                string sMySchemaName ,
                                string sMyColumnName )
      {
         bool result;
         result = false;
         /* Using cursor P00067 */
         pr_default.execute(5, new Object[] {sTableName, sMySchemaName, sMyColumnName});
         while ( (pr_default.getStatus(5) != 101) )
         {
            tablename = P00067_Atablename[0];
            ntablename = P00067_ntablename[0];
            schemaname = P00067_Aschemaname[0];
            nschemaname = P00067_nschemaname[0];
            columnname = P00067_Acolumnname[0];
            ncolumnname = P00067_ncolumnname[0];
            attrelid = P00067_Aattrelid[0];
            nattrelid = P00067_nattrelid[0];
            oid = P00067_Aoid[0];
            noid = P00067_noid[0];
            relname = P00067_Arelname[0];
            nrelname = P00067_nrelname[0];
            result = true;
            pr_default.readNext(5);
         }
         pr_default.close(5);
         return result ;
      }

      private void ExecuteOnlyTablesReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 1 ,  "ReorganizeTrn_Manager" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 2 ,  "ReorganizeTrn_SupplierGen" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 3 ,  "ReorganizeTrn_NetworkIndividual" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 4 ,  "ReorganizeTrn_Receptionist" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 5 ,  "ReorganizeTrn_Resident" , new Object[]{ });
      }

      private void ExecuteOnlyRisReorganization( )
      {
      }

      private void ExecuteTablesReorganization( )
      {
         ExecuteOnlyTablesReorganization( ) ;
         ExecuteOnlyRisReorganization( ) ;
         ReorgExecute.SubmitAll() ;
      }

      private void SetPrecedence( )
      {
         SetPrecedencetables( ) ;
         SetPrecedenceris( ) ;
      }

      private void SetPrecedencetables( )
      {
         GXReorganization.SetMsg( 1 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Trn_Manager", ""}) );
         GXReorganization.SetMsg( 2 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Trn_SupplierGen", ""}) );
         GXReorganization.SetMsg( 3 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Trn_NetworkIndividual", ""}) );
         GXReorganization.SetMsg( 4 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Trn_Receptionist", ""}) );
         GXReorganization.SetMsg( 5 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Trn_Resident", ""}) );
      }

      private void SetPrecedenceris( )
      {
      }

      private void ExecuteReorganization( )
      {
         if ( ErrCode == 0 )
         {
            TablesCount( ) ;
            if ( ! PrintOnlyRecordCount( ) )
            {
               FirstActions( ) ;
               SetPrecedence( ) ;
               ExecuteTablesReorganization( ) ;
            }
         }
      }

      public void UtilsCleanup( )
      {
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         P00012_ATrn_ManagerCount = new int[1] ;
         P00023_ATrn_SupplierGenCount = new int[1] ;
         P00034_ATrn_NetworkIndividualCount = new int[1] ;
         P00045_ATrn_ReceptionistCount = new int[1] ;
         P00056_ATrn_ResidentCount = new int[1] ;
         sSchemaVar = "";
         sTableName = "";
         sMySchemaName = "";
         sMyColumnName = "";
         tablename = "";
         ntablename = false;
         schemaname = "";
         nschemaname = false;
         columnname = "";
         ncolumnname = false;
         attrelid = "";
         nattrelid = false;
         oid = "";
         noid = false;
         relname = "";
         nrelname = false;
         P00067_Atablename = new string[] {""} ;
         P00067_ntablename = new bool[] {false} ;
         P00067_Aschemaname = new string[] {""} ;
         P00067_nschemaname = new bool[] {false} ;
         P00067_Acolumnname = new string[] {""} ;
         P00067_ncolumnname = new bool[] {false} ;
         P00067_Aattrelid = new string[] {""} ;
         P00067_nattrelid = new bool[] {false} ;
         P00067_Aoid = new string[] {""} ;
         P00067_noid = new bool[] {false} ;
         P00067_Arelname = new string[] {""} ;
         P00067_nrelname = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reorg__default(),
            new Object[][] {
                new Object[] {
               P00012_ATrn_ManagerCount
               }
               , new Object[] {
               P00023_ATrn_SupplierGenCount
               }
               , new Object[] {
               P00034_ATrn_NetworkIndividualCount
               }
               , new Object[] {
               P00045_ATrn_ReceptionistCount
               }
               , new Object[] {
               P00056_ATrn_ResidentCount
               }
               , new Object[] {
               P00067_Atablename, P00067_Aschemaname, P00067_Acolumnname, P00067_Aattrelid, P00067_Aoid, P00067_Arelname
               }
            }
         );
         /* GeneXus formulas. */
      }

      protected short ErrCode ;
      protected int Trn_ManagerCount ;
      protected int Trn_SupplierGenCount ;
      protected int Trn_NetworkIndividualCount ;
      protected int Trn_ReceptionistCount ;
      protected int Trn_ResidentCount ;
      protected string sSchemaVar ;
      protected string sTableName ;
      protected string sMySchemaName ;
      protected string sMyColumnName ;
      protected bool ntablename ;
      protected bool nschemaname ;
      protected bool ncolumnname ;
      protected bool nattrelid ;
      protected bool noid ;
      protected bool nrelname ;
      protected string tablename ;
      protected string schemaname ;
      protected string columnname ;
      protected string attrelid ;
      protected string oid ;
      protected string relname ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected GxCommand RGZ ;
      protected IDataStoreProvider pr_default ;
      protected int[] P00012_ATrn_ManagerCount ;
      protected int[] P00023_ATrn_SupplierGenCount ;
      protected int[] P00034_ATrn_NetworkIndividualCount ;
      protected int[] P00045_ATrn_ReceptionistCount ;
      protected int[] P00056_ATrn_ResidentCount ;
      protected string[] P00067_Atablename ;
      protected bool[] P00067_ntablename ;
      protected string[] P00067_Aschemaname ;
      protected bool[] P00067_nschemaname ;
      protected string[] P00067_Acolumnname ;
      protected bool[] P00067_ncolumnname ;
      protected string[] P00067_Aattrelid ;
      protected bool[] P00067_nattrelid ;
      protected string[] P00067_Aoid ;
      protected bool[] P00067_noid ;
      protected string[] P00067_Arelname ;
      protected bool[] P00067_nrelname ;
   }

   public class reorg__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00012;
          prmP00012 = new Object[] {
          };
          Object[] prmP00023;
          prmP00023 = new Object[] {
          };
          Object[] prmP00034;
          prmP00034 = new Object[] {
          };
          Object[] prmP00045;
          prmP00045 = new Object[] {
          };
          Object[] prmP00056;
          prmP00056 = new Object[] {
          };
          Object[] prmP00067;
          prmP00067 = new Object[] {
          new ParDef("sTableName",GXType.Char,255,0) ,
          new ParDef("sMySchemaName",GXType.Char,255,0) ,
          new ParDef("sMyColumnName",GXType.Char,255,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00012", "SELECT COUNT(*) FROM Trn_Manager ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00012,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00023", "SELECT COUNT(*) FROM Trn_SupplierGen ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00023,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00034", "SELECT COUNT(*) FROM Trn_NetworkIndividual ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00034,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00045", "SELECT COUNT(*) FROM Trn_Receptionist ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00045,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00056", "SELECT COUNT(*) FROM Trn_Resident ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00056,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00067", "SELECT T.TABLENAME, T.TABLEOWNER, T1.ATTNAME, T1.ATTRELID, T2.OID, T2.RELNAME FROM PG_TABLES T, PG_ATTRIBUTE T1, PG_CLASS T2 WHERE (UPPER(T.TABLENAME) = ( UPPER(:sTableName))) AND (UPPER(T.TABLEOWNER) = ( UPPER(:sMySchemaName))) AND (UPPER(T1.ATTNAME) = ( UPPER(:sMyColumnName))) AND (T2.OID = ( T1.ATTRELID)) AND (T2.RELNAME = ( T.TABLENAME)) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00067,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
       }
    }

 }

}
