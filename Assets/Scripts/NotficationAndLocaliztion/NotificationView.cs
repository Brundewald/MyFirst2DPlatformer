using System;
using Unity.Notifications.Android;
using UnityEngine;
using UnityEngine.UI;

public class NotificationView : MonoBehaviour
{
    private const string NotificationID = "android_notifier_id";
    [SerializeField] private string _notificationName = "Reward is ready";
    [SerializeField] private string _notificationDescription = "Your daily reward is ready!";
    [SerializeField] private float _repeatInterval;
    [SerializeField] private Button _notificationButton;

    private void Start()
    {
        _notificationButton.onClick.AddListener(CallNotification);
    }

    private void OnDestroy()
    {
        _notificationButton.onClick.RemoveListener(CallNotification);
    }

    private void CallNotification()
    {
        var androidSettingsChanel = new AndroidNotificationChannel()
        {
            Id = NotificationID,
            Name = _notificationName,
            Importance = Importance.High,
            CanBypassDnd = true,
            CanShowBadge = true,
            Description = _notificationDescription,
            EnableLights = true,
            EnableVibration = true,
            LockScreenVisibility = LockScreenVisibility.Public
        };
        
        AndroidNotificationCenter.RegisterNotificationChannel(androidSettingsChanel);

        var androidSettingsNotification = new AndroidNotification()
        {
            Color = Color.yellow,
            RepeatInterval = TimeSpan.FromSeconds(_repeatInterval)
        };

        AndroidNotificationCenter.SendNotification(androidSettingsNotification, NotificationID);
    }
}
