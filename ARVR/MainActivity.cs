using Android.App;
using Android.Widget;
using Android.OS;
using Com.Pikkart.AR.Geo;
using System.Collections.Generic;
using Android.Support.V4.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Locations;
using ARVR.Adapters;

namespace ARVR
{
    [Activity(Label = "ARVR", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : GeoActivity
    {
        int count = 1;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            CheckPermissions(m_permissionCode);
            //if not Android 6+ run the app
            if (Build.VERSION.SdkInt < BuildVersionCodes.M)
            {
                Init();
            }
            else
            {
                
            }
        }

        private int m_permissionCode = 1234;
        private void CheckPermissions(int code)
        {
            string[] permissions_required = new string[]{
               Android.Manifest.Permission.Camera,
               Android.Manifest.Permission.WriteExternalStorage,
               Android.Manifest.Permission.ReadExternalStorage,
               Android.Manifest.Permission.AccessNetworkState,
               Android.Manifest.Permission.AccessCoarseLocation,
               Android.Manifest.Permission.AccessFineLocation};

            List<string> permissions_not_granted_list = new List<string>();
            foreach (string permission in permissions_required)
            {
                if (ActivityCompat.CheckSelfPermission(this, permission) != Permission.Granted)
                {
                    permissions_not_granted_list.Add(permission);
                }
            }
            if (permissions_not_granted_list.Count > 0)
            {
                string[] permissions = new string[permissions_not_granted_list.Count];
                permissions = permissions_not_granted_list.ToArray();
                ActivityCompat.RequestPermissions(this, permissions, m_permissionCode);
            }
            else
            {
                Init();
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            if (requestCode == m_permissionCode)
            {
                bool isGranted = true;
                for (int i = 0; i < grantResults.Length; ++i)
                {
                    isGranted = isGranted && (grantResults[i] == Permission.Granted);
                }
                if (isGranted)
                {
                    Init();
                }
                else
                {
                    Toast.MakeText(this, "Error: required permissions not granted!", ToastLength.Short).Show();
                    Finish();
                }
            }
        }


        private void Init()
        {
            MarkerAdapter arMyMarkerViewAdapter = new MarkerAdapter(this, 51, 73);

            MarkerAdapter mapMyMarkerViewAdapter = new MarkerAdapter(this, 30, 43);

          //  InitGeoFragment(arMyMarkerViewAdapter, mapMyMarkerViewAdapter);

            InitGeoFragment();

            Location loc1 = new Location("loc1");
            loc1.Latitude = 45.466019;
            loc1.Longitude = 9.188020;

            List<GeoElement> geoElementList = new List<GeoElement>();
            geoElementList.Add(new GeoElement(loc1, "1", "Max Doc Berdugin"));

            SetGeoElements(geoElementList);

        }

        public override void OnGeoElementClicked(GeoElement p0)
        {
            Toast.MakeText(this, p0.Name + " is there", ToastLength.Short).Show();
        }


    }
}

