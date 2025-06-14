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
   public class prc_getlocationmemos : GXProcedure
   {
      public prc_getlocationmemos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getlocationmemos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ResidentId ,
                           short aP1_PageSize ,
                           short aP2_PageNumber ,
                           out string aP3_result )
      {
         this.AV18ResidentId = aP0_ResidentId;
         this.AV14PageSize = aP1_PageSize;
         this.AV13PageNumber = aP2_PageNumber;
         this.AV21result = "" ;
         initialize();
         ExecuteImpl();
         aP3_result=this.AV21result;
      }

      public string executeUdp( string aP0_ResidentId ,
                                short aP1_PageSize ,
                                short aP2_PageNumber )
      {
         execute(aP0_ResidentId, aP1_PageSize, aP2_PageNumber, out aP3_result);
         return AV21result ;
      }

      public void executeSubmit( string aP0_ResidentId ,
                                 short aP1_PageSize ,
                                 short aP2_PageNumber ,
                                 out string aP3_result )
      {
         this.AV18ResidentId = aP0_ResidentId;
         this.AV14PageSize = aP1_PageSize;
         this.AV13PageNumber = aP2_PageNumber;
         this.AV21result = "" ;
         SubmitImpl();
         aP3_result=this.AV21result;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00D02 */
         pr_default.execute(0, new Object[] {AV18ResidentId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A71ResidentGUID = P00D02_A71ResidentGUID[0];
            A62ResidentId = P00D02_A62ResidentId[0];
            A29LocationId = P00D02_A29LocationId[0];
            A11OrganisationId = P00D02_A11OrganisationId[0];
            AV15PrimaryResidentId = A62ResidentId;
            AV11LocationId = A29LocationId;
            AV12OrganisationId = A11OrganisationId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P00D04 */
         pr_default.execute(1, new Object[] {AV11LocationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            A40000GXC1 = P00D04_A40000GXC1[0];
            n40000GXC1 = P00D04_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(1);
         if ( ( AV14PageSize < 1 ) || ( AV13PageNumber < 1 ) )
         {
            AV17RecordsToSkip = 0;
            AV10defaultPageNumber = 1;
            AV16RecordsPerPage = 100;
         }
         else
         {
            AV16RecordsPerPage = AV14PageSize;
            AV10defaultPageNumber = AV13PageNumber;
            AV17RecordsToSkip = (short)(AV14PageSize*(AV13PageNumber-1));
         }
         AV20TotalRecords = (short)(A40000GXC1);
         AV19SDT_Memos = new GXBaseCollection<SdtSDT_Memo>( context, "SDT_Memo", "Comforta_version21");
         GXPagingFrom3 = AV17RecordsToSkip;
         GXPagingTo3 = AV16RecordsPerPage;
         /* Using cursor P00D05 */
         pr_default.execute(2, new Object[] {AV11LocationId, GXPagingFrom3, GXPagingTo3});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A29LocationId = P00D05_A29LocationId[0];
            A529SG_OrganisationId = P00D05_A529SG_OrganisationId[0];
            A11OrganisationId = P00D05_A11OrganisationId[0];
            A528SG_LocationId = P00D05_A528SG_LocationId[0];
            A550MemoTitle = P00D05_A550MemoTitle[0];
            A551MemoDescription = P00D05_A551MemoDescription[0];
            A552MemoImage = P00D05_A552MemoImage[0];
            n552MemoImage = P00D05_n552MemoImage[0];
            A553MemoDocument = P00D05_A553MemoDocument[0];
            n553MemoDocument = P00D05_n553MemoDocument[0];
            A561MemoStartDateTime = P00D05_A561MemoStartDateTime[0];
            n561MemoStartDateTime = P00D05_n561MemoStartDateTime[0];
            A562MemoEndDateTime = P00D05_A562MemoEndDateTime[0];
            n562MemoEndDateTime = P00D05_n562MemoEndDateTime[0];
            A563MemoDuration = P00D05_A563MemoDuration[0];
            n563MemoDuration = P00D05_n563MemoDuration[0];
            A564MemoRemoveDate = P00D05_A564MemoRemoveDate[0];
            n564MemoRemoveDate = P00D05_n564MemoRemoveDate[0];
            A62ResidentId = P00D05_A62ResidentId[0];
            A72ResidentSalutation = P00D05_A72ResidentSalutation[0];
            A64ResidentGivenName = P00D05_A64ResidentGivenName[0];
            A65ResidentLastName = P00D05_A65ResidentLastName[0];
            A71ResidentGUID = P00D05_A71ResidentGUID[0];
            A566MemoBgColorCode = P00D05_A566MemoBgColorCode[0];
            n566MemoBgColorCode = P00D05_n566MemoBgColorCode[0];
            A567MemoForm = P00D05_A567MemoForm[0];
            A624MemoType = P00D05_A624MemoType[0];
            A625MemoName = P00D05_A625MemoName[0];
            A626MemoLeftOffset = P00D05_A626MemoLeftOffset[0];
            A627MemoTopOffset = P00D05_A627MemoTopOffset[0];
            A628MemoTitleAngle = P00D05_A628MemoTitleAngle[0];
            A629MemoTitleScale = P00D05_A629MemoTitleScale[0];
            A637MemoTextFontName = P00D05_A637MemoTextFontName[0];
            A638MemoTextAlignment = P00D05_A638MemoTextAlignment[0];
            A639MemoIsBold = P00D05_A639MemoIsBold[0];
            A640MemoIsItalic = P00D05_A640MemoIsItalic[0];
            A641MemoIsCapitalized = P00D05_A641MemoIsCapitalized[0];
            A642MemoTextColor = P00D05_A642MemoTextColor[0];
            A549MemoId = P00D05_A549MemoId[0];
            A72ResidentSalutation = P00D05_A72ResidentSalutation[0];
            A64ResidentGivenName = P00D05_A64ResidentGivenName[0];
            A65ResidentLastName = P00D05_A65ResidentLastName[0];
            A71ResidentGUID = P00D05_A71ResidentGUID[0];
            AV9SDT_Memo = new SdtSDT_Memo(context);
            AV9SDT_Memo.gxTpr_Memoid = A549MemoId;
            AV9SDT_Memo.gxTpr_Memotitle = A550MemoTitle;
            AV9SDT_Memo.gxTpr_Memodescription = A551MemoDescription;
            AV9SDT_Memo.gxTpr_Memoimage = A552MemoImage;
            AV9SDT_Memo.gxTpr_Memodocument = A553MemoDocument;
            AV9SDT_Memo.gxTpr_Memostartdatetime = A561MemoStartDateTime;
            AV9SDT_Memo.gxTpr_Memoenddatetime = A562MemoEndDateTime;
            AV9SDT_Memo.gxTpr_Memoduration = A563MemoDuration;
            AV9SDT_Memo.gxTpr_Memoremovedate = A564MemoRemoveDate;
            AV9SDT_Memo.gxTpr_Residentid = A62ResidentId;
            AV9SDT_Memo.gxTpr_Residentsalutation = A72ResidentSalutation;
            AV9SDT_Memo.gxTpr_Residentgivenname = A64ResidentGivenName;
            AV9SDT_Memo.gxTpr_Residentlastname = A65ResidentLastName;
            AV9SDT_Memo.gxTpr_Residentguid = A71ResidentGUID;
            AV9SDT_Memo.gxTpr_Memobgcolorcode = A566MemoBgColorCode;
            AV9SDT_Memo.gxTpr_Memoform = A567MemoForm;
            AV9SDT_Memo.gxTpr_Createdby = A64ResidentGivenName+" "+A65ResidentLastName;
            AV9SDT_Memo.gxTpr_Memotype = A624MemoType;
            AV9SDT_Memo.gxTpr_Memoname = A625MemoName;
            AV9SDT_Memo.gxTpr_Memoleftoffset = A626MemoLeftOffset;
            AV9SDT_Memo.gxTpr_Memotopoffset = A627MemoTopOffset;
            AV9SDT_Memo.gxTpr_Memotitleangle = A628MemoTitleAngle;
            AV9SDT_Memo.gxTpr_Memotitlescale = A629MemoTitleScale;
            AV9SDT_Memo.gxTpr_Memotextfontname = A637MemoTextFontName;
            AV9SDT_Memo.gxTpr_Memotextalignment = A638MemoTextAlignment;
            AV9SDT_Memo.gxTpr_Memoisbold = A639MemoIsBold;
            AV9SDT_Memo.gxTpr_Memoisitalic = A640MemoIsItalic;
            AV9SDT_Memo.gxTpr_Memoiscapitalized = A641MemoIsCapitalized;
            AV9SDT_Memo.gxTpr_Memotextcolor = A642MemoTextColor;
            AV19SDT_Memos.Add(AV9SDT_Memo, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV22TotalPages = (short)((AV20TotalRecords+AV16RecordsPerPage-1)/ (decimal)(AV16RecordsPerPage));
         AV8SDT_ApiListResponse.gxTpr_Memos = AV19SDT_Memos;
         AV8SDT_ApiListResponse.gxTpr_Numberofpages = AV22TotalPages;
         AV8SDT_ApiListResponse.gxTpr_Pagenumber = AV10defaultPageNumber;
         AV8SDT_ApiListResponse.gxTpr_Pagesize = AV16RecordsPerPage;
         AV21result = AV8SDT_ApiListResponse.ToJSonString(false, true);
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
         AV21result = "";
         P00D02_A71ResidentGUID = new string[] {""} ;
         P00D02_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00D02_A29LocationId = new Guid[] {Guid.Empty} ;
         P00D02_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A71ResidentGUID = "";
         A62ResidentId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV15PrimaryResidentId = Guid.Empty;
         AV11LocationId = Guid.Empty;
         AV12OrganisationId = Guid.Empty;
         P00D04_A40000GXC1 = new int[1] ;
         P00D04_n40000GXC1 = new bool[] {false} ;
         AV19SDT_Memos = new GXBaseCollection<SdtSDT_Memo>( context, "SDT_Memo", "Comforta_version21");
         P00D05_A29LocationId = new Guid[] {Guid.Empty} ;
         P00D05_A529SG_OrganisationId = new Guid[] {Guid.Empty} ;
         P00D05_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00D05_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         P00D05_A550MemoTitle = new string[] {""} ;
         P00D05_A551MemoDescription = new string[] {""} ;
         P00D05_A552MemoImage = new string[] {""} ;
         P00D05_n552MemoImage = new bool[] {false} ;
         P00D05_A553MemoDocument = new string[] {""} ;
         P00D05_n553MemoDocument = new bool[] {false} ;
         P00D05_A561MemoStartDateTime = new DateTime[] {DateTime.MinValue} ;
         P00D05_n561MemoStartDateTime = new bool[] {false} ;
         P00D05_A562MemoEndDateTime = new DateTime[] {DateTime.MinValue} ;
         P00D05_n562MemoEndDateTime = new bool[] {false} ;
         P00D05_A563MemoDuration = new decimal[1] ;
         P00D05_n563MemoDuration = new bool[] {false} ;
         P00D05_A564MemoRemoveDate = new DateTime[] {DateTime.MinValue} ;
         P00D05_n564MemoRemoveDate = new bool[] {false} ;
         P00D05_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00D05_A72ResidentSalutation = new string[] {""} ;
         P00D05_A64ResidentGivenName = new string[] {""} ;
         P00D05_A65ResidentLastName = new string[] {""} ;
         P00D05_A71ResidentGUID = new string[] {""} ;
         P00D05_A566MemoBgColorCode = new string[] {""} ;
         P00D05_n566MemoBgColorCode = new bool[] {false} ;
         P00D05_A567MemoForm = new string[] {""} ;
         P00D05_A624MemoType = new string[] {""} ;
         P00D05_A625MemoName = new string[] {""} ;
         P00D05_A626MemoLeftOffset = new decimal[1] ;
         P00D05_A627MemoTopOffset = new decimal[1] ;
         P00D05_A628MemoTitleAngle = new decimal[1] ;
         P00D05_A629MemoTitleScale = new decimal[1] ;
         P00D05_A637MemoTextFontName = new string[] {""} ;
         P00D05_A638MemoTextAlignment = new string[] {""} ;
         P00D05_A639MemoIsBold = new bool[] {false} ;
         P00D05_A640MemoIsItalic = new bool[] {false} ;
         P00D05_A641MemoIsCapitalized = new bool[] {false} ;
         P00D05_A642MemoTextColor = new string[] {""} ;
         P00D05_A549MemoId = new Guid[] {Guid.Empty} ;
         A529SG_OrganisationId = Guid.Empty;
         A528SG_LocationId = Guid.Empty;
         A550MemoTitle = "";
         A551MemoDescription = "";
         A552MemoImage = "";
         A553MemoDocument = "";
         A561MemoStartDateTime = (DateTime)(DateTime.MinValue);
         A562MemoEndDateTime = (DateTime)(DateTime.MinValue);
         A564MemoRemoveDate = DateTime.MinValue;
         A72ResidentSalutation = "";
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A566MemoBgColorCode = "";
         A567MemoForm = "";
         A624MemoType = "";
         A625MemoName = "";
         A637MemoTextFontName = "";
         A638MemoTextAlignment = "";
         A642MemoTextColor = "";
         A549MemoId = Guid.Empty;
         AV9SDT_Memo = new SdtSDT_Memo(context);
         AV8SDT_ApiListResponse = new SdtSDT_ApiListResponse(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getlocationmemos__default(),
            new Object[][] {
                new Object[] {
               P00D02_A71ResidentGUID, P00D02_A62ResidentId, P00D02_A29LocationId, P00D02_A11OrganisationId
               }
               , new Object[] {
               P00D04_A40000GXC1, P00D04_n40000GXC1
               }
               , new Object[] {
               P00D05_A29LocationId, P00D05_A529SG_OrganisationId, P00D05_A11OrganisationId, P00D05_A528SG_LocationId, P00D05_A550MemoTitle, P00D05_A551MemoDescription, P00D05_A552MemoImage, P00D05_n552MemoImage, P00D05_A553MemoDocument, P00D05_n553MemoDocument,
               P00D05_A561MemoStartDateTime, P00D05_n561MemoStartDateTime, P00D05_A562MemoEndDateTime, P00D05_n562MemoEndDateTime, P00D05_A563MemoDuration, P00D05_n563MemoDuration, P00D05_A564MemoRemoveDate, P00D05_n564MemoRemoveDate, P00D05_A62ResidentId, P00D05_A72ResidentSalutation,
               P00D05_A64ResidentGivenName, P00D05_A65ResidentLastName, P00D05_A71ResidentGUID, P00D05_A566MemoBgColorCode, P00D05_n566MemoBgColorCode, P00D05_A567MemoForm, P00D05_A624MemoType, P00D05_A625MemoName, P00D05_A626MemoLeftOffset, P00D05_A627MemoTopOffset,
               P00D05_A628MemoTitleAngle, P00D05_A629MemoTitleScale, P00D05_A637MemoTextFontName, P00D05_A638MemoTextAlignment, P00D05_A639MemoIsBold, P00D05_A640MemoIsItalic, P00D05_A641MemoIsCapitalized, P00D05_A642MemoTextColor, P00D05_A549MemoId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV14PageSize ;
      private short AV13PageNumber ;
      private short AV17RecordsToSkip ;
      private short AV10defaultPageNumber ;
      private short AV16RecordsPerPage ;
      private short AV20TotalRecords ;
      private short AV22TotalPages ;
      private int A40000GXC1 ;
      private int GXPagingFrom3 ;
      private int GXPagingTo3 ;
      private decimal A563MemoDuration ;
      private decimal A626MemoLeftOffset ;
      private decimal A627MemoTopOffset ;
      private decimal A628MemoTitleAngle ;
      private decimal A629MemoTitleScale ;
      private string A72ResidentSalutation ;
      private string A567MemoForm ;
      private string A638MemoTextAlignment ;
      private DateTime A561MemoStartDateTime ;
      private DateTime A562MemoEndDateTime ;
      private DateTime A564MemoRemoveDate ;
      private bool n40000GXC1 ;
      private bool n552MemoImage ;
      private bool n553MemoDocument ;
      private bool n561MemoStartDateTime ;
      private bool n562MemoEndDateTime ;
      private bool n563MemoDuration ;
      private bool n564MemoRemoveDate ;
      private bool n566MemoBgColorCode ;
      private bool A639MemoIsBold ;
      private bool A640MemoIsItalic ;
      private bool A641MemoIsCapitalized ;
      private string AV21result ;
      private string A552MemoImage ;
      private string AV18ResidentId ;
      private string A71ResidentGUID ;
      private string A550MemoTitle ;
      private string A551MemoDescription ;
      private string A553MemoDocument ;
      private string A64ResidentGivenName ;
      private string A65ResidentLastName ;
      private string A566MemoBgColorCode ;
      private string A624MemoType ;
      private string A625MemoName ;
      private string A637MemoTextFontName ;
      private string A642MemoTextColor ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid AV15PrimaryResidentId ;
      private Guid AV11LocationId ;
      private Guid AV12OrganisationId ;
      private Guid A529SG_OrganisationId ;
      private Guid A528SG_LocationId ;
      private Guid A549MemoId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00D02_A71ResidentGUID ;
      private Guid[] P00D02_A62ResidentId ;
      private Guid[] P00D02_A29LocationId ;
      private Guid[] P00D02_A11OrganisationId ;
      private int[] P00D04_A40000GXC1 ;
      private bool[] P00D04_n40000GXC1 ;
      private GXBaseCollection<SdtSDT_Memo> AV19SDT_Memos ;
      private Guid[] P00D05_A29LocationId ;
      private Guid[] P00D05_A529SG_OrganisationId ;
      private Guid[] P00D05_A11OrganisationId ;
      private Guid[] P00D05_A528SG_LocationId ;
      private string[] P00D05_A550MemoTitle ;
      private string[] P00D05_A551MemoDescription ;
      private string[] P00D05_A552MemoImage ;
      private bool[] P00D05_n552MemoImage ;
      private string[] P00D05_A553MemoDocument ;
      private bool[] P00D05_n553MemoDocument ;
      private DateTime[] P00D05_A561MemoStartDateTime ;
      private bool[] P00D05_n561MemoStartDateTime ;
      private DateTime[] P00D05_A562MemoEndDateTime ;
      private bool[] P00D05_n562MemoEndDateTime ;
      private decimal[] P00D05_A563MemoDuration ;
      private bool[] P00D05_n563MemoDuration ;
      private DateTime[] P00D05_A564MemoRemoveDate ;
      private bool[] P00D05_n564MemoRemoveDate ;
      private Guid[] P00D05_A62ResidentId ;
      private string[] P00D05_A72ResidentSalutation ;
      private string[] P00D05_A64ResidentGivenName ;
      private string[] P00D05_A65ResidentLastName ;
      private string[] P00D05_A71ResidentGUID ;
      private string[] P00D05_A566MemoBgColorCode ;
      private bool[] P00D05_n566MemoBgColorCode ;
      private string[] P00D05_A567MemoForm ;
      private string[] P00D05_A624MemoType ;
      private string[] P00D05_A625MemoName ;
      private decimal[] P00D05_A626MemoLeftOffset ;
      private decimal[] P00D05_A627MemoTopOffset ;
      private decimal[] P00D05_A628MemoTitleAngle ;
      private decimal[] P00D05_A629MemoTitleScale ;
      private string[] P00D05_A637MemoTextFontName ;
      private string[] P00D05_A638MemoTextAlignment ;
      private bool[] P00D05_A639MemoIsBold ;
      private bool[] P00D05_A640MemoIsItalic ;
      private bool[] P00D05_A641MemoIsCapitalized ;
      private string[] P00D05_A642MemoTextColor ;
      private Guid[] P00D05_A549MemoId ;
      private SdtSDT_Memo AV9SDT_Memo ;
      private SdtSDT_ApiListResponse AV8SDT_ApiListResponse ;
      private string aP3_result ;
   }

   public class prc_getlocationmemos__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00D02;
          prmP00D02 = new Object[] {
          new ParDef("AV18ResidentId",GXType.VarChar,100,60)
          };
          Object[] prmP00D04;
          prmP00D04 = new Object[] {
          new ParDef("AV11LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00D05;
          prmP00D05 = new Object[] {
          new ParDef("AV11LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("GXPagingFrom3",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo3",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00D02", "SELECT ResidentGUID, ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE ResidentGUID = ( :AV18ResidentId) ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D02,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00D04", "SELECT COALESCE( T1.GXC1, 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM Trn_Memo WHERE SG_LocationId = :AV11LocationId ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D04,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D05", "SELECT T2.LocationId, T1.SG_OrganisationId, T2.OrganisationId, T1.SG_LocationId, T1.MemoTitle, T1.MemoDescription, T1.MemoImage, T1.MemoDocument, T1.MemoStartDateTime, T1.MemoEndDateTime, T1.MemoDuration, T1.MemoRemoveDate, T1.ResidentId, T2.ResidentSalutation, T2.ResidentGivenName, T2.ResidentLastName, T2.ResidentGUID, T1.MemoBgColorCode, T1.MemoForm, T1.MemoType, T1.MemoName, T1.MemoLeftOffset, T1.MemoTopOffset, T1.MemoTitleAngle, T1.MemoTitleScale, T1.MemoTextFontName, T1.MemoTextAlignment, T1.MemoIsBold, T1.MemoIsItalic, T1.MemoIsCapitalized, T1.MemoTextColor, T1.MemoId FROM (Trn_Memo T1 INNER JOIN Trn_Resident T2 ON T2.ResidentId = T1.ResidentId AND T2.LocationId = T1.SG_LocationId AND T2.OrganisationId = T1.SG_OrganisationId) WHERE T1.SG_LocationId = :AV11LocationId ORDER BY T1.MemoId DESC  OFFSET :GXPagingFrom3 LIMIT CASE WHEN :GXPagingTo3 > 0 THEN :GXPagingTo3 ELSE 1e9 END",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D05,100, GxCacheFrequency.OFF ,false,false )
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
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(11);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(12);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((Guid[]) buf[18])[0] = rslt.getGuid(13);
                ((string[]) buf[19])[0] = rslt.getString(14, 20);
                ((string[]) buf[20])[0] = rslt.getVarchar(15);
                ((string[]) buf[21])[0] = rslt.getVarchar(16);
                ((string[]) buf[22])[0] = rslt.getVarchar(17);
                ((string[]) buf[23])[0] = rslt.getVarchar(18);
                ((bool[]) buf[24])[0] = rslt.wasNull(18);
                ((string[]) buf[25])[0] = rslt.getString(19, 20);
                ((string[]) buf[26])[0] = rslt.getVarchar(20);
                ((string[]) buf[27])[0] = rslt.getVarchar(21);
                ((decimal[]) buf[28])[0] = rslt.getDecimal(22);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(23);
                ((decimal[]) buf[30])[0] = rslt.getDecimal(24);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(25);
                ((string[]) buf[32])[0] = rslt.getVarchar(26);
                ((string[]) buf[33])[0] = rslt.getString(27, 20);
                ((bool[]) buf[34])[0] = rslt.getBool(28);
                ((bool[]) buf[35])[0] = rslt.getBool(29);
                ((bool[]) buf[36])[0] = rslt.getBool(30);
                ((string[]) buf[37])[0] = rslt.getVarchar(31);
                ((Guid[]) buf[38])[0] = rslt.getGuid(32);
                return;
       }
    }

 }

}
