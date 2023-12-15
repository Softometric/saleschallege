using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Enums
{
    public enum NotificationTypeEnum
    {
        EmailWithSMTP = 1,
        EmailWithCredentials,
        SMS,
        PushNotification
    }
    public enum RegistrationStageEnum
    {
        LoginCreated = 0,
        ProfileInitiation = 1,
        ProfileActivation,
        PaymentInitiation,
        PaymentCompletion,
        Biodata,
        NextOfKin,
        ProgrammeApplication,
        EducationalRecord,
        OlevelResult,
        EmploymentRecord,
        PictureUpload,
        SubmitApplication,
        ApplicationSumitted
    }
    public enum ModeEnum
    {
        FullTime, PartTime
    }
    public enum GrantTypeEnum
    {
        client_credentials, password

    }
    public enum PaymentTypeEnum
    {
        ApplicationFee = 1,
        AcceptanceFee,
        OrientationFee,
        SchoolFee,
        SchoolFeePart
    }
    public enum RequirementTypeEnum
    {
        Elective,
        Core,
        GeneralStudies,
        Faculty,
        Others
    }
    public enum SemesterEnum
    {
        Harmattan,
        Rain
    }
    public enum FrequencyEnum
    {
        Daily, Weekly, Monthly, Yearly, None
    }
    public enum TransactionTypeEnum
    {
        WalletTopUp,
        InvestmentTopUp,
        SavingsTopUp
    }
    public enum AccountEnum
    {
        CustomerWalletAccount,
        BaigeWalletChargeAccount,
        BaigeWalletBankAccount
    }
    public enum TransactionStatusEnum
    {
        Pending, Failed, Succeded
    }

}
