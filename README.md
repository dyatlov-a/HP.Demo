# Демо Web-сервис
1. Возможность авторизации в системе нескольких пользователей;
2. Возможность просмотра списка пользователей;
3. Пользователь может быть включон в одну из двух групп: обычные пользователи или администраторы;
4. Администраторы могут:
- создавать пользователей;
- редактировать пользователей;
- удалять пользователей;
- добавлять пользователей в группу администраторов;
- исключать пользователей из группы администраторов


## Развертывание (Visual Studio 2017)
- Построить решение, восстановить пакеты Nuget
- Сконфигурировать строку подключения к БД
- При помощи Package-Manager Console выполнить команду **update-database**
- Запустить исполнение проекта

## Swagger
В Development окружении подключен Swagger.

Для выполнения запросов необходимо авторизоваться в системе `POST /api/v1/auth`

При помощи вкладки Authorize указать ключ

![Swagger auth](https://downloader.disk.yandex.ru/disk/a360976f126b7dd4c94f26343ffd7a8850ef753b3c4e4a70636a39b7090a51a8/5b4481c1/Qmww8fbko1CPknEnRbQg1a2YnTQOTfv87efxa021r82mQeVhwLh12zdp6lwOd0JAzKXGLdqWn1vgj2ahU2_e8g%3D%3D?uid=0&filename=Swagger1.png&disposition=inline&hash=&limit=0&content_type=image%2Fpng&fsize=20181&hid=3be22b0778da5b7fccdf771a1d2c3409&media_type=image&tknv=v2&etag=a390b86a3f2e6ea0112645620600e6cb)

В поле Value: необходимо ввести `Bearer {key}`.

![Swagger key](https://downloader.disk.yandex.ru/disk/2b2696ec11063cd102fb55f9baae21dcad107e2872da1890947b6311e8795042/5b44826c/Qmww8fbko1CPknEnRbQg1XUyv_9A0epOzwZ8gqIowg7lGRGv5NkEudOVMLeVBhtat9ukb_oSEpl1CxHjWyU00Q%3D%3D?uid=0&filename=Swagger2.png&disposition=inline&hash=&limit=0&content_type=image%2Fpng&fsize=23772&hid=e7580d333eebfb7388842d176bb4ba55&media_type=image&tknv=v2&etag=6b0aba138a2e9c9b94f64f2db34bce2c)

### Учетные данные администратора
- Email **admin@admin.ru**
- Password **12345678**