| Description                          | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-192-GCM (AES-NI)       | 128B         |     107.38 ns |     1.255 ns |     1.048 ns |         - |
| Decrypt · AES-192-GCM (OS)           | 128B         |     123.75 ns |     1.555 ns |     1.378 ns |         - |
| Decrypt · AES-192-GCM (Managed)      | 128B         |     549.96 ns |     3.495 ns |     3.269 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle) | 128B         |     989.14 ns |    12.971 ns |    10.832 ns |    1728 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-192-GCM (AES-NI)       | 128B         |      77.26 ns |     0.535 ns |     0.474 ns |         - |
| Encrypt · AES-192-GCM (OS)           | 128B         |     119.56 ns |     0.604 ns |     0.535 ns |         - |
| Encrypt · AES-192-GCM (Managed)      | 128B         |     510.66 ns |     1.967 ns |     1.642 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle) | 128B         |     887.72 ns |     4.391 ns |     4.107 ns |    1712 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)           | 1KB          |     190.32 ns |     1.639 ns |     1.369 ns |         - |
| Decrypt · AES-192-GCM (AES-NI)       | 1KB          |     299.88 ns |     3.745 ns |     3.320 ns |         - |
| Decrypt · AES-192-GCM (Managed)      | 1KB          |   3,568.62 ns |    29.838 ns |    27.910 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle) | 1KB          |   4,192.98 ns |    31.221 ns |    27.676 ns |    1728 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)           | 1KB          |     175.00 ns |     0.719 ns |     0.600 ns |         - |
| Encrypt · AES-192-GCM (AES-NI)       | 1KB          |     293.05 ns |     1.349 ns |     1.261 ns |         - |
| Encrypt · AES-192-GCM (Managed)      | 1KB          |   3,513.56 ns |    13.219 ns |    11.719 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle) | 1KB          |   4,085.92 ns |    50.464 ns |    44.735 ns |    1712 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)           | 8KB          |     755.63 ns |     7.308 ns |     6.478 ns |         - |
| Decrypt · AES-192-GCM (AES-NI)       | 8KB          |   1,840.65 ns |    14.321 ns |    12.695 ns |         - |
| Decrypt · AES-192-GCM (Managed)      | 8KB          |  27,625.41 ns |   250.761 ns |   222.294 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle) | 8KB          |  29,644.38 ns |   116.514 ns |   108.987 ns |    1728 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)           | 8KB          |     678.19 ns |     3.899 ns |     3.256 ns |         - |
| Encrypt · AES-192-GCM (AES-NI)       | 8KB          |   2,024.24 ns |    11.487 ns |    10.745 ns |         - |
| Encrypt · AES-192-GCM (Managed)      | 8KB          |  27,598.32 ns |   151.104 ns |   126.178 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle) | 8KB          |  29,772.60 ns |   337.023 ns |   298.762 ns |    1712 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)           | 128KB        |  11,627.30 ns |    97.867 ns |    91.545 ns |         - |
| Decrypt · AES-192-GCM (AES-NI)       | 128KB        |  29,823.83 ns |   202.200 ns |   179.245 ns |         - |
| Decrypt · AES-192-GCM (Managed)      | 128KB        | 444,684.19 ns | 8,512.266 ns | 7,962.379 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle) | 128KB        | 467,970.51 ns | 2,814.142 ns | 2,632.350 ns |    1728 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)           | 128KB        |  10,185.38 ns |   102.295 ns |    90.682 ns |         - |
| Encrypt · AES-192-GCM (AES-NI)       | 128KB        |  31,911.30 ns |   394.306 ns |   329.263 ns |         - |
| Encrypt · AES-192-GCM (Managed)      | 128KB        | 440,840.61 ns | 4,418.457 ns | 3,916.847 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle) | 128KB        | 479,451.42 ns | 9,123.757 ns | 8,534.368 ns |    1712 B |