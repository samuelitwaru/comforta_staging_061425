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
namespace GeneXus.Programs.workwithplus {
   public class wwp_calendar_getevents : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public wwp_calendar_getevents( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_calendar_getevents( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( bool aP0_IsSearching ,
                           string aP1_TitleFilter ,
                           DateTime aP2_LoadFromDate ,
                           DateTime aP3_LoadToDate ,
                           out GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item> aP4_Gxm2rootcol )
      {
         this.AV5IsSearching = aP0_IsSearching;
         this.AV8TitleFilter = aP1_TitleFilter;
         this.AV6LoadFromDate = aP2_LoadFromDate;
         this.AV7LoadToDate = aP3_LoadToDate;
         this.Gxm2rootcol = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item>( context, "Item", "Comforta_version21") ;
         initialize();
         ExecuteImpl();
         aP4_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item> executeUdp( bool aP0_IsSearching ,
                                                                                                     string aP1_TitleFilter ,
                                                                                                     DateTime aP2_LoadFromDate ,
                                                                                                     DateTime aP3_LoadToDate )
      {
         execute(aP0_IsSearching, aP1_TitleFilter, aP2_LoadFromDate, aP3_LoadToDate, out aP4_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( bool aP0_IsSearching ,
                                 string aP1_TitleFilter ,
                                 DateTime aP2_LoadFromDate ,
                                 DateTime aP3_LoadToDate ,
                                 out GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item> aP4_Gxm2rootcol )
      {
         this.AV5IsSearching = aP0_IsSearching;
         this.AV8TitleFilter = aP1_TitleFilter;
         this.AV6LoadFromDate = aP2_LoadFromDate;
         this.AV7LoadToDate = aP3_LoadToDate;
         this.Gxm2rootcol = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item>( context, "Item", "Comforta_version21") ;
         SubmitImpl();
         aP4_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! AV5IsSearching )
         {
            AV9RealLoadToDate = DateTimeUtil.DAdd( AV7LoadToDate, (1));
         }
         if ( AV5IsSearching )
         {
            AV9RealLoadToDate = AV7LoadToDate;
         }
         AV14Udparg3 = new prc_getuserlocationid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV6LoadFromDate ,
                                              AV9RealLoadToDate ,
                                              AV8TitleFilter ,
                                              A270AgendaCalendarStartDate ,
                                              A271AgendaCalendarEndDate ,
                                              A269AgendaCalendarTitle ,
                                              A437AgendaCalendarRecurring ,
                                              AV14Udparg3 ,
                                              A29LocationId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV8TitleFilter = StringUtil.Concat( StringUtil.RTrim( AV8TitleFilter), "%", "");
         /* Using cursor P000E2 */
         pr_default.execute(0, new Object[] {AV14Udparg3, AV6LoadFromDate, AV9RealLoadToDate, AV6LoadFromDate, AV6LoadFromDate, lV8TitleFilter});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A269AgendaCalendarTitle = P000E2_A269AgendaCalendarTitle[0];
            A271AgendaCalendarEndDate = P000E2_A271AgendaCalendarEndDate[0];
            A270AgendaCalendarStartDate = P000E2_A270AgendaCalendarStartDate[0];
            A29LocationId = P000E2_A29LocationId[0];
            A437AgendaCalendarRecurring = P000E2_A437AgendaCalendarRecurring[0];
            A268AgendaCalendarId = P000E2_A268AgendaCalendarId[0];
            A272AgendaCalendarAllDay = P000E2_A272AgendaCalendarAllDay[0];
            Gxm1wwp_calendar_events = new WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item(context);
            Gxm2rootcol.Add(Gxm1wwp_calendar_events, 0);
            Gxm1wwp_calendar_events.gxTpr_Id = A268AgendaCalendarId.ToString();
            Gxm1wwp_calendar_events.gxTpr_Allday = A272AgendaCalendarAllDay;
            Gxm1wwp_calendar_events.gxTpr_Start = A270AgendaCalendarStartDate;
            Gxm1wwp_calendar_events.gxTpr_End = A271AgendaCalendarEndDate;
            Gxm1wwp_calendar_events.gxTpr_Title = A269AgendaCalendarTitle;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV16GXV2 = 1;
         GXt_objcol_SdtWWP_Calendar_Events_Item1 = AV15GXV1;
         new prc_agendarecurringevent(context ).execute(  AV5IsSearching,  AV8TitleFilter,  AV6LoadFromDate,  AV7LoadToDate, out  GXt_objcol_SdtWWP_Calendar_Events_Item1) ;
         AV15GXV1 = GXt_objcol_SdtWWP_Calendar_Events_Item1;
         while ( AV16GXV2 <= AV15GXV1.Count )
         {
            AV10CalendarEvent = ((WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item)AV15GXV1.Item(AV16GXV2));
            Gxm1wwp_calendar_events = new WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item(context);
            Gxm2rootcol.Add(Gxm1wwp_calendar_events, 0);
            Gxm1wwp_calendar_events.gxTpr_Id = AV10CalendarEvent.gxTpr_Id;
            Gxm1wwp_calendar_events.gxTpr_Allday = AV10CalendarEvent.gxTpr_Allday;
            Gxm1wwp_calendar_events.gxTpr_Start = AV10CalendarEvent.gxTpr_Start;
            Gxm1wwp_calendar_events.gxTpr_End = AV10CalendarEvent.gxTpr_End;
            Gxm1wwp_calendar_events.gxTpr_Title = AV10CalendarEvent.gxTpr_Title;
            AV16GXV2 = (int)(AV16GXV2+1);
         }
         AV18GXV4 = 1;
         GXt_objcol_SdtWWP_Calendar_Events_Item1 = AV17GXV3;
         new prc_recurringeverystartdate(context ).execute(  AV5IsSearching,  AV8TitleFilter,  AV6LoadFromDate,  AV7LoadToDate, out  GXt_objcol_SdtWWP_Calendar_Events_Item1) ;
         AV17GXV3 = GXt_objcol_SdtWWP_Calendar_Events_Item1;
         while ( AV18GXV4 <= AV17GXV3.Count )
         {
            AV10CalendarEvent = ((WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item)AV17GXV3.Item(AV18GXV4));
            Gxm1wwp_calendar_events = new WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item(context);
            Gxm2rootcol.Add(Gxm1wwp_calendar_events, 0);
            Gxm1wwp_calendar_events.gxTpr_Id = AV10CalendarEvent.gxTpr_Id;
            Gxm1wwp_calendar_events.gxTpr_Allday = AV10CalendarEvent.gxTpr_Allday;
            Gxm1wwp_calendar_events.gxTpr_Start = AV10CalendarEvent.gxTpr_Start;
            Gxm1wwp_calendar_events.gxTpr_End = AV10CalendarEvent.gxTpr_End;
            Gxm1wwp_calendar_events.gxTpr_Title = AV10CalendarEvent.gxTpr_Title;
            AV18GXV4 = (int)(AV18GXV4+1);
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
         AV9RealLoadToDate = DateTime.MinValue;
         AV14Udparg3 = Guid.Empty;
         lV8TitleFilter = "";
         A270AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         A271AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         A269AgendaCalendarTitle = "";
         A29LocationId = Guid.Empty;
         P000E2_A269AgendaCalendarTitle = new string[] {""} ;
         P000E2_A271AgendaCalendarEndDate = new DateTime[] {DateTime.MinValue} ;
         P000E2_A270AgendaCalendarStartDate = new DateTime[] {DateTime.MinValue} ;
         P000E2_A29LocationId = new Guid[] {Guid.Empty} ;
         P000E2_A437AgendaCalendarRecurring = new bool[] {false} ;
         P000E2_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         P000E2_A272AgendaCalendarAllDay = new bool[] {false} ;
         A268AgendaCalendarId = Guid.Empty;
         Gxm1wwp_calendar_events = new WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item(context);
         AV15GXV1 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item>( context, "Item", "Comforta_version21");
         AV10CalendarEvent = new WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item(context);
         AV17GXV3 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item>( context, "Item", "Comforta_version21");
         GXt_objcol_SdtWWP_Calendar_Events_Item1 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item>( context, "Item", "Comforta_version21");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_calendar_getevents__default(),
            new Object[][] {
                new Object[] {
               P000E2_A269AgendaCalendarTitle, P000E2_A271AgendaCalendarEndDate, P000E2_A270AgendaCalendarStartDate, P000E2_A29LocationId, P000E2_A437AgendaCalendarRecurring, P000E2_A268AgendaCalendarId, P000E2_A272AgendaCalendarAllDay
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV16GXV2 ;
      private int AV18GXV4 ;
      private DateTime AV6LoadFromDate ;
      private DateTime A270AgendaCalendarStartDate ;
      private DateTime A271AgendaCalendarEndDate ;
      private DateTime AV7LoadToDate ;
      private DateTime AV9RealLoadToDate ;
      private bool AV5IsSearching ;
      private bool A437AgendaCalendarRecurring ;
      private bool A272AgendaCalendarAllDay ;
      private string AV8TitleFilter ;
      private string lV8TitleFilter ;
      private string A269AgendaCalendarTitle ;
      private Guid AV14Udparg3 ;
      private Guid A29LocationId ;
      private Guid A268AgendaCalendarId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item> Gxm2rootcol ;
      private IDataStoreProvider pr_default ;
      private string[] P000E2_A269AgendaCalendarTitle ;
      private DateTime[] P000E2_A271AgendaCalendarEndDate ;
      private DateTime[] P000E2_A270AgendaCalendarStartDate ;
      private Guid[] P000E2_A29LocationId ;
      private bool[] P000E2_A437AgendaCalendarRecurring ;
      private Guid[] P000E2_A268AgendaCalendarId ;
      private bool[] P000E2_A272AgendaCalendarAllDay ;
      private WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item Gxm1wwp_calendar_events ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item> AV15GXV1 ;
      private WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item AV10CalendarEvent ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item> AV17GXV3 ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item> GXt_objcol_SdtWWP_Calendar_Events_Item1 ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item> aP4_Gxm2rootcol ;
   }

   public class wwp_calendar_getevents__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000E2( IGxContext context ,
                                             DateTime AV6LoadFromDate ,
                                             DateTime AV9RealLoadToDate ,
                                             string AV8TitleFilter ,
                                             DateTime A270AgendaCalendarStartDate ,
                                             DateTime A271AgendaCalendarEndDate ,
                                             string A269AgendaCalendarTitle ,
                                             bool A437AgendaCalendarRecurring ,
                                             Guid AV14Udparg3 ,
                                             Guid A29LocationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[6];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT AgendaCalendarTitle, AgendaCalendarEndDate, AgendaCalendarStartDate, LocationId, AgendaCalendarRecurring, AgendaCalendarId, AgendaCalendarAllDay FROM Trn_AgendaCalendar";
         AddWhere(sWhereString, "(LocationId = :AV14Udparg3)");
         AddWhere(sWhereString, "(AgendaCalendarRecurring = FALSE)");
         if ( ! (DateTime.MinValue==AV6LoadFromDate) && ! (DateTime.MinValue==AV9RealLoadToDate) )
         {
            AddWhere(sWhereString, "(AgendaCalendarStartDate >= :AV6LoadFromDate and AgendaCalendarStartDate < :AV9RealLoadToDate or AgendaCalendarStartDate < :AV6LoadFromDate and AgendaCalendarEndDate >= :AV6LoadFromDate)");
         }
         else
         {
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8TitleFilter)) )
         {
            AddWhere(sWhereString, "(AgendaCalendarTitle like '%' || :lV8TitleFilter)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY LocationId";
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
                     return conditional_P000E2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (Guid)dynConstraints[7] , (Guid)dynConstraints[8] );
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
          Object[] prmP000E2;
          prmP000E2 = new Object[] {
          new ParDef("AV14Udparg3",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV6LoadFromDate",GXType.DateTime,8,5) ,
          new ParDef("AV9RealLoadToDate",GXType.Date,8,0) ,
          new ParDef("AV6LoadFromDate",GXType.DateTime,8,5) ,
          new ParDef("AV6LoadFromDate",GXType.DateTime,8,5) ,
          new ParDef("lV8TitleFilter",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000E2,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                ((bool[]) buf[6])[0] = rslt.getBool(7);
                return;
       }
    }

 }

}
