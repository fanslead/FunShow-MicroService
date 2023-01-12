import { createLocalStorage } from '/@/utils/cache'
import { defHttp } from '/@/utils/http/axios'

export function initApplicationConfiguration() {
  defHttp
    .get(
      {
        url: '/api/abp/application-configuration',
        params: {
          IncludeLocalizationResources: false,
        },
      },
      {
        isTransformResponse: false,
      },
    )
    .then((res) => {
      createLocalStorage().set('application_configuration', res)
    })
}
