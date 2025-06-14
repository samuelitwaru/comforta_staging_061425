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
   public class prc_getresidentfilledforms : GXProcedure
   {
      public prc_getresidentfilledforms( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getresidentfilledforms( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ResidentGUID ,
                           short aP1_PageSize ,
                           short aP2_PageNumber ,
                           out string aP3_result )
      {
         this.AV8ResidentGUID = aP0_ResidentGUID;
         this.AV18PageSize = aP1_PageSize;
         this.AV19PageNumber = aP2_PageNumber;
         this.AV11result = "" ;
         initialize();
         ExecuteImpl();
         aP3_result=this.AV11result;
      }

      public string executeUdp( string aP0_ResidentGUID ,
                                short aP1_PageSize ,
                                short aP2_PageNumber )
      {
         execute(aP0_ResidentGUID, aP1_PageSize, aP2_PageNumber, out aP3_result);
         return AV11result ;
      }

      public void executeSubmit( string aP0_ResidentGUID ,
                                 short aP1_PageSize ,
                                 short aP2_PageNumber ,
                                 out string aP3_result )
      {
         this.AV8ResidentGUID = aP0_ResidentGUID;
         this.AV18PageSize = aP1_PageSize;
         this.AV19PageNumber = aP2_PageNumber;
         this.AV11result = "" ;
         SubmitImpl();
         aP3_result=this.AV11result;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00AV3 */
         pr_default.execute(0, new Object[] {AV8ResidentGUID});
         if ( (pr_default.getStatus(0) != 101) )
         {
            A40000GXC1 = P00AV3_A40000GXC1[0];
            n40000GXC1 = P00AV3_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(0);
         AV16SDT_ApiResidentFilledForms = new GXBaseCollection<SdtSDT_ApiResidentFilledForms>( context, "SDT_ApiResidentFilledForms", "Comforta_version21");
         AV24SDT_ApiListResponse = new SdtSDT_ApiListResponse(context);
         if ( ( AV18PageSize < 1 ) || ( AV19PageNumber < 1 ) )
         {
            AV20RecordsToSkip = 0;
            AV25defaultPageNumber = 1;
            AV21RecordsPerPage = 100;
         }
         else
         {
            AV21RecordsPerPage = AV18PageSize;
            AV25defaultPageNumber = AV19PageNumber;
            AV20RecordsToSkip = (short)(AV18PageSize*(AV19PageNumber-1));
         }
         AV22TotalRecords = (short)(A40000GXC1);
         GXPagingFrom2 = AV20RecordsToSkip;
         GXPagingTo2 = AV21RecordsPerPage;
         /* Using cursor P00AV4 */
         pr_default.execute(1, new Object[] {AV8ResidentGUID, GXPagingFrom2, GXPagingTo2});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A112WWPUserExtendedId = P00AV4_A112WWPUserExtendedId[0];
            A239WWPFormInstanceDate = P00AV4_A239WWPFormInstanceDate[0];
            A206WWPFormId = P00AV4_A206WWPFormId[0];
            A208WWPFormReferenceName = P00AV4_A208WWPFormReferenceName[0];
            A207WWPFormVersionNumber = P00AV4_A207WWPFormVersionNumber[0];
            A209WWPFormTitle = P00AV4_A209WWPFormTitle[0];
            A214WWPFormInstanceId = P00AV4_A214WWPFormInstanceId[0];
            A208WWPFormReferenceName = P00AV4_A208WWPFormReferenceName[0];
            A209WWPFormTitle = P00AV4_A209WWPFormTitle[0];
            AV17SDT_ResidentFilledFormsItem = new SdtSDT_ApiResidentFilledForms(context);
            AV17SDT_ResidentFilledFormsItem.gxTpr_Formfilleddate = A239WWPFormInstanceDate;
            AV17SDT_ResidentFilledFormsItem.gxTpr_Forminstanceid = (short)(A214WWPFormInstanceId);
            AV17SDT_ResidentFilledFormsItem.gxTpr_Formid = A206WWPFormId;
            AV17SDT_ResidentFilledFormsItem.gxTpr_Formreferencename = A208WWPFormReferenceName;
            AV17SDT_ResidentFilledFormsItem.gxTpr_Formversionnumber = A207WWPFormVersionNumber;
            AV17SDT_ResidentFilledFormsItem.gxTpr_Formtitle = A209WWPFormTitle;
            AV16SDT_ApiResidentFilledForms.Add(AV17SDT_ResidentFilledFormsItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV23TotalPages = (short)((AV22TotalRecords+AV21RecordsPerPage-1)/ (decimal)(AV21RecordsPerPage));
         AV24SDT_ApiListResponse.gxTpr_Numberofpages = AV23TotalPages;
         AV24SDT_ApiListResponse.gxTpr_Pagenumber = AV25defaultPageNumber;
         AV24SDT_ApiListResponse.gxTpr_Pagesize = AV21RecordsPerPage;
         AV24SDT_ApiListResponse.gxTpr_Filledforms = AV16SDT_ApiResidentFilledForms;
         AV11result = AV24SDT_ApiListResponse.ToJSonString(false, true);
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

      protected override void CloseCursors( )
      {
      }

      public override void initialize( )
      {
         AV11result = "";
         P00AV3_A40000GXC1 = new int[1] ;
         P00AV3_n40000GXC1 = new bool[] {false} ;
         AV16SDT_ApiResidentFilledForms = new GXBaseCollection<SdtSDT_ApiResidentFilledForms>( context, "SDT_ApiResidentFilledForms", "Comforta_version21");
         AV24SDT_ApiListResponse = new SdtSDT_ApiListResponse(context);
         P00AV4_A112WWPUserExtendedId = new string[] {""} ;
         P00AV4_A239WWPFormInstanceDate = new DateTime[] {DateTime.MinValue} ;
         P00AV4_A206WWPFormId = new short[1] ;
         P00AV4_A208WWPFormReferenceName = new string[] {""} ;
         P00AV4_A207WWPFormVersionNumber = new short[1] ;
         P00AV4_A209WWPFormTitle = new string[] {""} ;
         P00AV4_A214WWPFormInstanceId = new int[1] ;
         A112WWPUserExtendedId = "";
         A239WWPFormInstanceDate = (DateTime)(DateTime.MinValue);
         A208WWPFormReferenceName = "";
         A209WWPFormTitle = "";
         AV17SDT_ResidentFilledFormsItem = new SdtSDT_ApiResidentFilledForms(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getresidentfilledforms__default(),
            new Object[][] {
                new Object[] {
               P00AV3_A40000GXC1, P00AV3_n40000GXC1
               }
               , new Object[] {
               P00AV4_A112WWPUserExtendedId, P00AV4_A239WWPFormInstanceDate, P00AV4_A206WWPFormId, P00AV4_A208WWPFormReferenceName, P00AV4_A207WWPFormVersionNumber, P00AV4_A209WWPFormTitle, P00AV4_A214WWPFormInstanceId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18PageSize ;
      private short AV19PageNumber ;
      private short AV20RecordsToSkip ;
      private short AV25defaultPageNumber ;
      private short AV21RecordsPerPage ;
      private short AV22TotalRecords ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short AV23TotalPages ;
      private int A40000GXC1 ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A214WWPFormInstanceId ;
      private string A112WWPUserExtendedId ;
      private DateTime A239WWPFormInstanceDate ;
      private bool n40000GXC1 ;
      private string AV11result ;
      private string AV8ResidentGUID ;
      private string A208WWPFormReferenceName ;
      private string A209WWPFormTitle ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00AV3_A40000GXC1 ;
      private bool[] P00AV3_n40000GXC1 ;
      private GXBaseCollection<SdtSDT_ApiResidentFilledForms> AV16SDT_ApiResidentFilledForms ;
      private SdtSDT_ApiListResponse AV24SDT_ApiListResponse ;
      private string[] P00AV4_A112WWPUserExtendedId ;
      private DateTime[] P00AV4_A239WWPFormInstanceDate ;
      private short[] P00AV4_A206WWPFormId ;
      private string[] P00AV4_A208WWPFormReferenceName ;
      private short[] P00AV4_A207WWPFormVersionNumber ;
      private string[] P00AV4_A209WWPFormTitle ;
      private int[] P00AV4_A214WWPFormInstanceId ;
      private SdtSDT_ApiResidentFilledForms AV17SDT_ResidentFilledFormsItem ;
      private string aP3_result ;
   }

   public class prc_getresidentfilledforms__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00AV3;
          prmP00AV3 = new Object[] {
          new ParDef("AV8ResidentGUID",GXType.VarChar,100,60)
          };
          Object[] prmP00AV4;
          prmP00AV4 = new Object[] {
          new ParDef("AV8ResidentGUID",GXType.VarChar,100,60) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AV3", "SELECT COALESCE( T1.GXC1, 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM WWP_FormInstance WHERE WWPUserExtendedId = ( :AV8ResidentGUID) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AV3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AV4", "SELECT T1.WWPUserExtendedId, T1.WWPFormInstanceDate, T1.WWPFormId, T2.WWPFormReferenceName, T1.WWPFormVersionNumber, T2.WWPFormTitle, T1.WWPFormInstanceId FROM (WWP_FormInstance T1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber) WHERE T1.WWPUserExtendedId = ( :AV8ResidentGUID) ORDER BY T1.WWPFormInstanceId DESC  OFFSET :GXPagingFrom2 LIMIT CASE WHEN :GXPagingTo2 > 0 THEN :GXPagingTo2 ELSE 1e9 END",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AV4,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 40);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
