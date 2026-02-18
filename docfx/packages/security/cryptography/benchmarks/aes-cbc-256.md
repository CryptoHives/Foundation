| Description                          | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CBC (AES-NI)       | 128B         |      31.06 ns |     0.179 ns |     0.168 ns |         - |
| Decrypt · AES-256-CBC (OS)           | 128B         |     246.70 ns |     0.929 ns |     0.824 ns |     128 B |
| Decrypt · AES-256-CBC (Managed)      | 128B         |     573.85 ns |     2.505 ns |     2.344 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 128B         |     868.32 ns |     3.410 ns |     3.023 ns |    1024 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-CBC (AES-NI)       | 128B         |     183.75 ns |     0.834 ns |     0.780 ns |         - |
| Encrypt · AES-256-CBC (OS)           | 128B         |     309.33 ns |     2.570 ns |     2.404 ns |     128 B |
| Encrypt · AES-256-CBC (Managed)      | 128B         |     501.98 ns |     4.807 ns |     4.261 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 128B         |     789.47 ns |     6.389 ns |     5.664 ns |    1024 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-256-CBC (AES-NI)       | 1KB          |     109.51 ns |     0.297 ns |     0.263 ns |         - |
| Decrypt · AES-256-CBC (OS)           | 1KB          |     320.56 ns |     0.833 ns |     0.739 ns |     128 B |
| Decrypt · AES-256-CBC (Managed)      | 1KB          |   3,967.05 ns |    14.935 ns |    13.239 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 1KB          |   4,798.56 ns |    29.753 ns |    27.831 ns |    1024 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)           | 1KB          |     899.79 ns |     4.768 ns |     4.460 ns |     128 B |
| Encrypt · AES-256-CBC (AES-NI)       | 1KB          |   1,451.13 ns |     6.366 ns |     5.954 ns |         - |
| Encrypt · AES-256-CBC (Managed)      | 1KB          |   3,998.67 ns |    44.861 ns |    41.963 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 1KB          |   4,729.69 ns |    52.951 ns |    49.530 ns |    1024 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-256-CBC (AES-NI)       | 8KB          |     719.98 ns |     3.084 ns |     2.884 ns |         - |
| Decrypt · AES-256-CBC (OS)           | 8KB          |     934.02 ns |     2.973 ns |     2.781 ns |     128 B |
| Decrypt · AES-256-CBC (Managed)      | 8KB          |  31,097.22 ns |   190.452 ns |   168.831 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 8KB          |  35,859.97 ns |   139.613 ns |   116.583 ns |    1024 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)           | 8KB          |   5,909.67 ns |    36.888 ns |    34.505 ns |     128 B |
| Encrypt · AES-256-CBC (AES-NI)       | 8KB          |  11,512.52 ns |    63.420 ns |    59.323 ns |         - |
| Encrypt · AES-256-CBC (Managed)      | 8KB          |  31,735.36 ns |   195.183 ns |   173.024 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 8KB          |  36,416.50 ns |   361.657 ns |   338.294 ns |    1024 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)           | 128KB        |  11,297.82 ns |    19.576 ns |    17.354 ns |     128 B |
| Decrypt · AES-256-CBC (AES-NI)       | 128KB        |  11,331.06 ns |    45.687 ns |    40.501 ns |         - |
| Decrypt · AES-256-CBC (Managed)      | 128KB        | 495,443.99 ns | 2,898.195 ns | 2,569.174 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 128KB        | 570,264.40 ns | 3,155.067 ns | 2,796.885 ns |    1024 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)           | 128KB        |  91,314.87 ns |   296.244 ns |   262.613 ns |     128 B |
| Encrypt · AES-256-CBC (AES-NI)       | 128KB        | 183,999.23 ns |   373.492 ns |   331.091 ns |         - |
| Encrypt · AES-256-CBC (Managed)      | 128KB        | 508,386.21 ns | 4,559.604 ns | 4,265.056 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 128KB        | 574,103.92 ns | 5,139.210 ns | 4,807.220 ns |    1024 B |