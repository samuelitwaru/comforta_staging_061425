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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_df_validateuniquereferencename : GXProcedure
   {
      public wwp_df_validateuniquereferencename( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_validateuniquereferencename( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_WWPFormId ,
                           string aP1_WWPFormReferenceName ,
                           out bool aP2_IsUnique )
      {
         this.AV9WWPFormId = aP0_WWPFormId;
         this.AV10WWPFormReferenceName = aP1_WWPFormReferenceName;
         this.AV8IsUnique = false ;
         initialize();
         ExecuteImpl();
         aP2_IsUnique=this.AV8IsUnique;
      }

      public bool executeUdp( short aP0_WWPFormId ,
                              string aP1_WWPFormReferenceName )
      {
         execute(aP0_WWPFormId, aP1_WWPFormReferenceName, out aP2_IsUnique);
         return AV8IsUnique ;
      }

      public void executeSubmit( short aP0_WWPFormId ,
                                 string aP1_WWPFormReferenceName ,
                                 out bool aP2_IsUnique )
      {
         this.AV9WWPFormId = aP0_WWPFormId;
         this.AV10WWPFormReferenceName = aP1_WWPFormReferenceName;
         this.AV8IsUnique = false ;
         SubmitImpl();
         aP2_IsUnique=this.AV8IsUnique;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8IsUnique = true;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV9WWPFormId ,
                                              A206WWPFormId ,
                                              AV10WWPFormReferenceName ,
                                              A208WWPFormReferenceName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00432 */
         pr_default.execute(0, new Object[] {AV10WWPFormReferenceName, AV9WWPFormId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A208WWPFormReferenceName = P00432_A208WWPFormReferenceName[0];
            A207WWPFormVersionNumber = P00432_A207WWPFormVersionNumber[0];
            A206WWPFormId = P00432_A206WWPFormId[0];
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            if ( A207WWPFormVersionNumber == A219WWPFormLatestVersionNumber )
            {
               AV8IsUnique = false;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
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
         A208WWPFormReferenceName = "";
         P00432_A208WWPFormReferenceName = new string[] {""} ;
         P00432_A207WWPFormVersionNumber = new short[1] ;
         P00432_A206WWPFormId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_validateuniquereferencename__default(),
            new Object[][] {
                new Object[] {
               P00432_A208WWPFormReferenceName, P00432_A207WWPFormVersionNumber, P00432_A206WWPFormId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9WWPFormId ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short A219WWPFormLatestVersionNumber ;
      private short GXt_int1 ;
      private bool AV8IsUnique ;
      private string AV10WWPFormReferenceName ;
      private string A208WWPFormReferenceName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00432_A208WWPFormReferenceName ;
      private short[] P00432_A207WWPFormVersionNumber ;
      private short[] P00432_A206WWPFormId ;
      private bool aP2_IsUnique ;
   }

   public class wwp_df_validateuniquereferencename__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00432( IGxContext context ,
                                             short AV9WWPFormId ,
                                             short A206WWPFormId ,
                                             string AV10WWPFormReferenceName ,
                                             string A208WWPFormReferenceName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[2];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT WWPFormReferenceName, WWPFormVersionNumber, WWPFormId FROM WWP_Form";
         AddWhere(sWhereString, "(WWPFormReferenceName = ( :AV10WWPFormReferenceName))");
         if ( ! (0==AV9WWPFormId) )
         {
            AddWhere(sWhereString, "(WWPFormId <> :AV9WWPFormId)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY WWPFormReferenceName, WWPFormVersionNumber DESC";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00432(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP00432;
          prmP00432 = new Object[] {
          new ParDef("AV10WWPFormReferenceName",GXType.VarChar,100,0) ,
          new ParDef("AV9WWPFormId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00432", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00432,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
