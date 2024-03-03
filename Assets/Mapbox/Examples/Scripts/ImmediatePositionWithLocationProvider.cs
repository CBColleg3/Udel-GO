namespace Mapbox.Examples
{
	using Mapbox.Unity.Location;
	using Mapbox.Unity.Map;
	using Mapbox.Examples;
	using Mapbox.Utils;
	using UnityEngine;

	public class ImmediatePositionWithLocationProvider : MonoBehaviour
	{

		bool _isInitialized;

		ILocationProvider _locationProvider;
		ILocationProvider LocationProvider
		{
			get
			{
				if (_locationProvider == null)
				{
					_locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider;
				}

				return _locationProvider;
			}
		}

		Vector3 _targetPosition;

		void Start()
		{
			LocationProviderFactory.Instance.mapManager.OnInitialized += () => _isInitialized = true;
		}

		void LateUpdate()
		{
			//Debug.Log("x: " + Input.location.lastData.latitude + ": y:  " + Input.location.lastData.longitude);
			if (_isInitialized)
			{
				var map = LocationProviderFactory.Instance.mapManager;
				var locationWalking = new Vector2d(Input.location.lastData.latitude, Input.location.lastData.longitude);
				//LocationProvider.CurrentLocation.LatitudeLongitude
				transform.localPosition = map.GeoToWorldPosition(locationWalking);
			}
		}
	}
}