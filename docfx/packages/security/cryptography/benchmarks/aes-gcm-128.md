| Description                          | TestDataSize | Mean         | Error        | StdDev       | Allocated |
|------------------------------------- |------------- |-------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-GCM (OS)           | 128B         |     118.1 ns |      0.71 ns |      0.63 ns |         - |
| Decrypt · AES-128-GCM (Managed)      | 128B         |     845.2 ns |      5.28 ns |      4.94 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle) | 128B         |     888.5 ns |      7.93 ns |      7.03 ns |    1624 B |
|                                      |              |              |              |              |           |
| Encrypt · AES-128-GCM (OS)           | 128B         |     117.8 ns |      0.64 ns |      0.56 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle) | 128B         |     786.1 ns |      7.10 ns |      6.64 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)      | 128B         |     804.2 ns |      5.69 ns |      5.04 ns |         - |
|                                      |              |              |              |              |           |
| Decrypt · AES-128-GCM (OS)           | 1KB          |     180.2 ns |      1.10 ns |      1.03 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle) | 1KB          |   3,669.0 ns |     17.29 ns |     13.50 ns |    1624 B |
| Decrypt · AES-128-GCM (Managed)      | 1KB          |   5,550.3 ns |     39.24 ns |     34.79 ns |         - |
|                                      |              |              |              |              |           |
| Encrypt · AES-128-GCM (OS)           | 1KB          |     182.5 ns |      2.45 ns |      2.29 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle) | 1KB          |   3,544.2 ns |     22.58 ns |     21.13 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)      | 1KB          |   5,450.7 ns |     44.61 ns |     41.73 ns |         - |
|                                      |              |              |              |              |           |
| Decrypt · AES-128-GCM (OS)           | 8KB          |     690.5 ns |      4.57 ns |      4.28 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle) | 8KB          |  25,665.2 ns |    175.01 ns |    163.71 ns |    1624 B |
| Decrypt · AES-128-GCM (Managed)      | 8KB          |  42,785.5 ns |    142.40 ns |    126.24 ns |         - |
|                                      |              |              |              |              |           |
| Encrypt · AES-128-GCM (OS)           | 8KB          |     678.2 ns |     12.46 ns |     11.04 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle) | 8KB          |  25,824.5 ns |    490.12 ns |    434.48 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)      | 8KB          |  43,481.9 ns |    629.68 ns |    558.20 ns |         - |
|                                      |              |              |              |              |           |
| Decrypt · AES-128-GCM (OS)           | 128KB        |  10,739.0 ns |     59.71 ns |     52.93 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle) | 128KB        | 406,844.8 ns |  2,117.70 ns |  1,980.90 ns |    1624 B |
| Decrypt · AES-128-GCM (Managed)      | 128KB        | 681,126.1 ns |  4,521.61 ns |  4,229.52 ns |         - |
|                                      |              |              |              |              |           |
| Encrypt · AES-128-GCM (OS)           | 128KB        |   9,749.8 ns |     50.63 ns |     44.88 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle) | 128KB        | 405,396.5 ns |  2,874.10 ns |  2,688.43 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)      | 128KB        | 716,953.7 ns | 14,326.99 ns | 19,126.12 ns |         - |