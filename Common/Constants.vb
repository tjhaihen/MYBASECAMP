Namespace QIS.Common
    Public NotInheritable Class Constants
        Public NotInheritable Class GroupCode
            Public Const Sex_SCode As String = "SEX"
            Public Const Religion_SCode As String = "RELIGION"
            Public Const Nationality_SCode As String = "NATIONALITY"
            Public Const Priority_SCode As String = "PRIORITY"
            Public Const ProjectStatus_SCode As String = "PROJECTSTATUS"
            Public Const ProductRoadmap_SCode As String = "PRODUCTROADMAP"
            Public Const IssueType_SCode As String = "ISSUETYPE"
            Public Const IssueStatus_SCode As String = "ISSUESTATUS"
            Public Const IssuePriority_SCode As String = "ISSUEPRIORITY"
            Public Const IssueConfirmStatus_SCode As String = "ISSUECONFIRMSTS"
            Public Const FileDirectory_SCode As String = "FILEDIR"
            Public Const ResponseType_SCode As String = "RESPONSETYPE"
            Public Const System_SCode As String = "SYSTEM"
            Public Const Tracking_SCode As String = "TRACKING"
            Public Const Delimiter_SCode As String = "DELIMITER"
            Public Const WorktimeReport_SCode As String = "WORKTIMEREPORT"

            Public Const EMRAssessmentType_SCode As String = "ASSESSMENTTYPE"

            Public Const NAAsalInformasi_SCode As String = "INFOSOURCE"
            Public Const NAHubungan_SCode As String = "RELATIONSHIP"
            Public Const NAJenisAlergi_SCode As String = "ALERGYTYPE"
            Public Const NADenyutNadi_SCode As String = "PULSETYPE"
            Public Const NAMetodeNyeri_SCode As String = "PAINMETHOD"
            Public Const NAKualitasNyeri_SCode As String = "PAINQUALITY"
            Public Const NAKarakteristikNyeri_SCode As String = "PAINCHAR"
            Public Const NANyeriBerkurang_SCode As String = "PAINRELIEFBY"
            Public Const NANyeriBertambah_SCode As String = "PAININCREASEBY"
            Public Const NAAktivitasMobilisasi_SCode As String = "ACTIVITYMOBILE"
            Public Const NAStatusPsikologi_SCode As String = "PHYSICSTAT"
            Public Const NAStatusMental_SCode As String = "MENTALSTAT"
            Public Const NAStatusTempatTinggal_SCode As String = "HOMESTAT"
            Public Const NAStatusGizi_SCode As String = "NUTRITIONSTAT"
            Public Const NAStatusPerubahanBeratBadan_SCode As String = "WEIGHTSTAT"
            Public Const NABahasa_SCode As String = "LANGUAGE"
            Public Const NACaraBelajar_SCode As String = "LEARNTYPE"
        End Class

        Public NotInheritable Class StandardCode
            Public Const PurchaseOrderType_SCode As String = "X145"
        End Class

        Public NotInheritable Class StandardField
            Public Const StatusPernikahan_SField As String = "STKAWIN"
            Public Const Pekerjaan_SField As String = "PEKERJAAN"
            Public Const JenisInstansi_SField As String = "JNINSTANSI"
            Public Const Pendidikan_SField As String = "PDDN"
            Public Const Triage_SField As String = "TRIAGE"
            Public Const Agama_SField As String = "AGAMA"
            Public Const Kesadaran_SField As String = "KDNDATANG"
            Public Const KeadaanKeluar_SField As String = "KDNKELUAR"
            Public Const CaraKeluar_SField As String = "CARAKELUAR"
        End Class

        Public NotInheritable Class ArrSeparator
            Public Const DefaultArrSeparator As String = "|"            
        End Class

        Public NotInheritable Class FormatString
            Public Const FORMAT_DATE As String = "dd-MM-yyyy"
            Public Const FORMAT_TIME As String = "HH:mm"
            Public Const FORMAT_CURRENCY As String = "#,##0.00"
        End Class

        Public NotInheritable Class MenuID            
            Public Const Profile_MenuID As String = "1001"
            Public Const ProjectGroup_MenuID As String = "1004"
            Public Const Project_MenuID As String = "1005"
            Public Const People_MenuID As String = "1009"
            Public Const Progress_MenuID As String = "5000"
            Public Const CommonCode_MenuID As String = "9008"
            Public Const SystemParameter_MenuID As String = "9009"
            Public Const ChangePassword_MenuID As String = "9010"
            Public Const BudgetAccount_MenuID As String = "6001"
            Public Const BudgetPurchasing_MenuID As String = "6002"
            Public Const AccountingBalance_MenuID As String = "4001"
        End Class

        Public NotInheritable Class ReportID
            Public Const ClientIssue_ReportID As String = "1000"
            Public Const IssueTicketForm_ReportID As String = "2001"
            Public Const CustomerSupportWeeklyReport_ReportID As String = "3001"
            Public Const PatchDashboard_ReportID As String = "5001"
            Public Const PatchDetail_ReportID As String = "5002"
            Public Const Worktime_ReportID As String = "8001"
        End Class

        Public NotInheritable Class MaskFormat
            Public Const TIME_MASK As String = "99:99"
        End Class

        Public NotInheritable Class MessageBoxText
            Public Const Validate_IsSystem As String = "This record is used by system and cannot be modified or deleted."
            Public Const Validate_EffeciveDateCannotEmpty As String = "Effective Date cannot empty. If the record use No Effective Date, please mark this option and try to save the record again."
            Public Const Validate_FileNameAlreadyExist As String = "File Name already exists. Upload failed. Please rename the file and try uploading again."
            Public Const Validate_CommonCodeNotFound As String = "Common Code data not found."
        End Class

        Public NotInheritable Class Parameter
            Public Const IS_DISPLAY_REPORT_CRITERIA As String = "isDisplayReportCriteria"
            Public Const PARAM_FORMAT_MRN As String = "format_norm"
        End Class

        Public NotInheritable Class ReportTypePanelID
            Public Const ServiceAcceptance_PanelID As String = "pnlServiceAcceptance"
            Public Const SummaryOfInspection_PanelID As String = "pnlSummaryOfInspection"
            Public Const TimeSheet_PanelID As String = "pnlTimeSheet"
            Public Const DailyProgressReport_PanelID As String = "pnlDailyProgressReport"
            Public Const DailyProgressReportMPI_PanelID As String = "pnlDailyProgressReportMPI"
            Public Const ServiceReport_PanelID As String = "pnlServiceReport"
            Public Const MPIReport_PanelID As String = "pnlMPIReport"
            Public Const DrillPipeInspectionReport_PanelID As String = "pnlDrillPipeInspectionReport"
            Public Const ThoroughVisualInspectionReport_PanelID As String = "pnlThoroughVisualInspectionReport"
            Public Const InspectionTallyReport_PanelID As String = "pnlInspectionTallyReport"
            Public Const UTSpotCheck_PanelID As String = "pnlUTSpotCheck"
            Public Const InspectionReport_PanelID As String = "pnlInspectionReport"
            Public Const UTSpotArea_PanelID As String = "pnlUTSpotArea"
            Public Const CheckListCompletionReport_PanelID As String = "pnlCheckListCompletionReport"
            Public Const CertificateOfInspection_PanelID As String = "pnlCertificateInspection"
            Public Const HardnessTest_PanelID As String = "pnlHardnessTestReport"
            Public Const OfficialReport_PanelID As String = "pnlBeritaAcara"
        End Class

        Public NotInheritable Class IDPrefix
            Public Const WorkRequestPrefix As String = "WR"            
        End Class

        Public NotInheritable Class Delimiter
            Public Const Delimiter_HISJO As String = "HISJO"
        End Class

        Public NotInheritable Class IssueTypeCode
            Public Const IssueType_Open As String = "001"
            Public Const IssueType_Bugs As String = "002"
            Public Const IssueType_DataSetting As String = "003"
            Public Const IssueType_Guidance As String = "004"
            Public Const IssueType_Modification As String = "005"
            Public Const IssueType_Request As String = "009"
        End Class

        Public NotInheritable Class IssueStatusCode
            Public Const IssueStatus_Open As String = "001"
            Public Const IssueStatus_InProgress As String = "002"
            Public Const IssueStatus_Finish As String = "003"
            Public Const IssueStatus_NeedSample As String = "004"
        End Class

        Public NotInheritable Class IssuePriorityCode
            Public Const IssuePriority_Low As String = "001"
            Public Const IssuePriority_Medium As String = "002"
            Public Const IssuePriority_High As String = "003"
        End Class

        Public NotInheritable Class IssueConfirmStatsusCode
            Public Const IssueConfirmStatus_Open As String = "001"
            Public Const IssueConfirmStatus_InDiscussion As String = "002"
            Public Const IssueConfirmStatus_Confirmed As String = "003"
        End Class

        Public NotInheritable Class SystemSetting
            Public Const SystemSetting_SYSEMR As String = "SYSEMR"
            Public Const SystemSetting_DBOHIS As String = "DBOHIS"
            Public Const SystemSetting_HISPHUNITID As String = "HISPHUNITID"
            Public Const SystemSetting_HISPHITEMID As String = "HISPHITEMID"
            Public Const SystemSetting_VERSIAPP As String = "VER"
        End Class

        Public NotInheritable Class Tracking
            Public Const Tracking_IN As String = "IN"
            Public Const Tracking_RM As String = "RM"
        End Class

        Public NotInheritable Class FileDirectoryType
            Public Const FileDirectory_Issue As String = "ISSUEUPLDIR"
            Public Const FileDirectory_PatientDocuments As String = "PATIENTDOCDIR"
        End Class

        Public NotInheritable Class GetImageType
            Public Const GetImage_CommonCodeFilePic As String = "CommonCodeFilePic"            
        End Class

        Public NotInheritable Class TableName
            Public Const IssueTable As String = "Issue"
        End Class
    End Class
End Namespace

