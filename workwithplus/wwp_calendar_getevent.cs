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
   public class wwp_calendar_getevent : GXProcedure
   {
      public wwp_calendar_getevent( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_calendar_getevent( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_EventId ,
                           out WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item aP1_Calendar_Event )
      {
         this.AV9EventId = aP0_EventId;
         this.AV8Calendar_Event = new WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item(context) ;
         initialize();
         ExecuteImpl();
         aP1_Calendar_Event=this.AV8Calendar_Event;
      }

      public WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item executeUdp( string aP0_EventId )
      {
         execute(aP0_EventId, out aP1_Calendar_Event);
         return AV8Calendar_Event ;
      }

      public void executeSubmit( string aP0_EventId ,
                                 out WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item aP1_Calendar_Event )
      {
         this.AV9EventId = aP0_EventId;
         this.AV8Calendar_Event = new WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item(context) ;
         SubmitImpl();
         aP1_Calendar_Event=this.AV8Calendar_Event;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11AgendaCalendarId = StringUtil.StrToGuid( AV9EventId);
         /* Using cursor P006I2 */
         pr_default.execute(0, new Object[] {AV11AgendaCalendarId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A268AgendaCalendarId = P006I2_A268AgendaCalendarId[0];
            A272AgendaCalendarAllDay = P006I2_A272AgendaCalendarAllDay[0];
            A269AgendaCalendarTitle = P006I2_A269AgendaCalendarTitle[0];
            A270AgendaCalendarStartDate = P006I2_A270AgendaCalendarStartDate[0];
            A271AgendaCalendarEndDate = P006I2_A271AgendaCalendarEndDate[0];
            AV8Calendar_Event = new WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item(context);
            AV8Calendar_Event.gxTpr_Id = AV11AgendaCalendarId.ToString();
            AV8Calendar_Event.gxTpr_Allday = A272AgendaCalendarAllDay;
            AV8Calendar_Event.gxTpr_Title = A269AgendaCalendarTitle;
            AV8Calendar_Event.gxTpr_Start = A270AgendaCalendarStartDate;
            AV8Calendar_Event.gxTpr_End = A271AgendaCalendarEndDate;
            /* Exiting from a For First loop. */
            if (true) break;
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
         AV8Calendar_Event = new WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item(context);
         AV11AgendaCalendarId = Guid.Empty;
         P006I2_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         P006I2_A272AgendaCalendarAllDay = new bool[] {false} ;
         P006I2_A269AgendaCalendarTitle = new string[] {""} ;
         P006I2_A270AgendaCalendarStartDate = new DateTime[] {DateTime.MinValue} ;
         P006I2_A271AgendaCalendarEndDate = new DateTime[] {DateTime.MinValue} ;
         A268AgendaCalendarId = Guid.Empty;
         A269AgendaCalendarTitle = "";
         A270AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         A271AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_calendar_getevent__default(),
            new Object[][] {
                new Object[] {
               P006I2_A268AgendaCalendarId, P006I2_A272AgendaCalendarAllDay, P006I2_A269AgendaCalendarTitle, P006I2_A270AgendaCalendarStartDate, P006I2_A271AgendaCalendarEndDate
               }
            }
         );
         /* GeneXus formulas. */
      }

      private DateTime A270AgendaCalendarStartDate ;
      private DateTime A271AgendaCalendarEndDate ;
      private bool A272AgendaCalendarAllDay ;
      private string AV9EventId ;
      private string A269AgendaCalendarTitle ;
      private Guid AV11AgendaCalendarId ;
      private Guid A268AgendaCalendarId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item AV8Calendar_Event ;
      private IDataStoreProvider pr_default ;
      private Guid[] P006I2_A268AgendaCalendarId ;
      private bool[] P006I2_A272AgendaCalendarAllDay ;
      private string[] P006I2_A269AgendaCalendarTitle ;
      private DateTime[] P006I2_A270AgendaCalendarStartDate ;
      private DateTime[] P006I2_A271AgendaCalendarEndDate ;
      private WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item aP1_Calendar_Event ;
   }

   public class wwp_calendar_getevent__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP006I2;
          prmP006I2 = new Object[] {
          new ParDef("AV11AgendaCalendarId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006I2", "SELECT AgendaCalendarId, AgendaCalendarAllDay, AgendaCalendarTitle, AgendaCalendarStartDate, AgendaCalendarEndDate FROM Trn_AgendaCalendar WHERE AgendaCalendarId = :AV11AgendaCalendarId ORDER BY AgendaCalendarId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006I2,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                return;
       }
    }

 }

}
