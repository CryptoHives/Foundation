| Description                          | TestDataSize | Mean          | Error        | StdDev       | Median        | Allocated |
|------------------------------------- |------------- |--------------:|-------------:|-------------:|--------------:|----------:|
| Decrypt · AES-128-GCM (AES-NI)       | 128B         |     103.26 ns |     0.653 ns |     0.611 ns |     103.23 ns |         - |
| Decrypt · AES-128-GCM (OS)           | 128B         |     118.13 ns |     0.947 ns |     0.885 ns |     118.16 ns |         - |
| Decrypt · AES-128-GCM (Managed)      | 128B         |     486.14 ns |     3.267 ns |     3.056 ns |     485.81 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle) | 128B         |     882.26 ns |     8.570 ns |     7.597 ns |     883.64 ns |    1624 B |
|                                      |              |               |              |              |               |           |
| Encrypt · AES-128-GCM (AES-NI)       | 128B         |      69.49 ns |     0.229 ns |     0.214 ns |      69.42 ns |         - |
| Encrypt · AES-128-GCM (OS)           | 128B         |     117.34 ns |     1.029 ns |     0.963 ns |     117.40 ns |         - |
| Encrypt · AES-128-GCM (Managed)      | 128B         |     472.75 ns |     9.451 ns |    22.826 ns |     463.99 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle) | 128B         |     797.54 ns |     6.915 ns |     5.774 ns |     799.88 ns |    1608 B |
|                                      |              |               |              |              |               |           |
| Decrypt · AES-128-GCM (OS)           | 1KB          |     176.48 ns |     1.886 ns |     1.764 ns |     176.21 ns |         - |
| Decrypt · AES-128-GCM (AES-NI)       | 1KB          |     282.96 ns |     1.702 ns |     1.592 ns |     283.15 ns |         - |
| Decrypt · AES-128-GCM (Managed)      | 1KB          |   3,137.28 ns |    31.115 ns |    29.105 ns |   3,138.01 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle) | 1KB          |   3,666.70 ns |    37.383 ns |    34.968 ns |   3,673.14 ns |    1624 B |
|                                      |              |               |              |              |               |           |
| Encrypt · AES-128-GCM (OS)           | 1KB          |     171.69 ns |     1.816 ns |     1.699 ns |     170.97 ns |         - |
| Encrypt · AES-128-GCM (AES-NI)       | 1KB          |     238.10 ns |     1.875 ns |     1.754 ns |     238.14 ns |         - |
| Encrypt · AES-128-GCM (Managed)      | 1KB          |   3,095.79 ns |    24.116 ns |    22.558 ns |   3,098.93 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle) | 1KB          |   3,578.45 ns |    37.010 ns |    34.619 ns |   3,572.11 ns |    1608 B |
|                                      |              |               |              |              |               |           |
| Decrypt · AES-128-GCM (OS)           | 8KB          |     677.97 ns |     6.261 ns |     5.857 ns |     675.47 ns |         - |
| Decrypt · AES-128-GCM (AES-NI)       | 8KB          |   1,808.62 ns |    10.670 ns |     9.459 ns |   1,805.67 ns |         - |
| Decrypt · AES-128-GCM (Managed)      | 8KB          |  24,336.99 ns |   166.297 ns |   147.418 ns |  24,325.96 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle) | 8KB          |  25,624.44 ns |   174.474 ns |   163.203 ns |  25,585.60 ns |    1624 B |
|                                      |              |               |              |              |               |           |
| Encrypt · AES-128-GCM (OS)           | 8KB          |     660.57 ns |     5.958 ns |     5.573 ns |     661.37 ns |         - |
| Encrypt · AES-128-GCM (AES-NI)       | 8KB          |   1,680.37 ns |     9.102 ns |     7.601 ns |   1,679.38 ns |         - |
| Encrypt · AES-128-GCM (Managed)      | 8KB          |  24,161.34 ns |   239.352 ns |   223.890 ns |  24,065.96 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle) | 8KB          |  25,721.08 ns |   128.380 ns |   120.086 ns |  25,706.72 ns |    1608 B |
|                                      |              |               |              |              |               |           |
| Decrypt · AES-128-GCM (OS)           | 128KB        |  11,714.12 ns |    96.351 ns |    85.413 ns |  11,709.83 ns |         - |
| Decrypt · AES-128-GCM (AES-NI)       | 128KB        |  27,794.08 ns |   119.024 ns |    99.390 ns |  27,777.62 ns |         - |
| Decrypt · AES-128-GCM (Managed)      | 128KB        | 384,838.69 ns | 3,457.289 ns | 3,233.950 ns | 383,309.42 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle) | 128KB        | 405,029.26 ns | 2,746.269 ns | 2,568.862 ns | 404,871.14 ns |    1624 B |
|                                      |              |               |              |              |               |           |
| Encrypt · AES-128-GCM (OS)           | 128KB        |   9,803.48 ns |    83.369 ns |    73.904 ns |   9,805.93 ns |         - |
| Encrypt · AES-128-GCM (AES-NI)       | 128KB        |  26,113.62 ns |   206.889 ns |   183.402 ns |  26,099.39 ns |         - |
| Encrypt · AES-128-GCM (Managed)      | 128KB        | 386,481.26 ns | 3,772.290 ns | 3,528.603 ns | 386,462.79 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle) | 128KB        | 403,389.45 ns | 3,156.969 ns | 2,953.030 ns | 403,380.79 ns |    1608 B |