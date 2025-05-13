using Android.Provider;

namespace LoDo.MAUI.NativeServices;

public class MessageReader
{
    public List<string> GetSmsMessages(string senderNumber)
    {
        var smsList = new List<string>();
        var uri = Telephony.Sms.Inbox.ContentUri;
        string[] projection = { Telephony.Sms.InterfaceConsts.Body, Telephony.Sms.InterfaceConsts.Address };

        string selection = Telephony.Sms.InterfaceConsts.Address + " = ?";
        string[] selectionArgs = { senderNumber };

        using (var cursor =
               Android.App.Application.Context.ContentResolver.Query(uri, projection, selection, selectionArgs,
                   "date DESC"))
        {
            if (cursor != null)
            {
                while (cursor.MoveToNext())
                {
                    string body = cursor.GetString(cursor.GetColumnIndexOrThrow(Telephony.Sms.InterfaceConsts.Body));
                    smsList.Add(body);
                }

                cursor.Close();
            }
        }

        return smsList;
    }
}