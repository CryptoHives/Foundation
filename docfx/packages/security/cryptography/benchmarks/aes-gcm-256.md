| Description                          | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-GCM (AES-NI)       | 128B         |     108.33 ns |     0.539 ns |     0.504 ns |         - |
| Decrypt · AES-256-GCM (OS)           | 128B         |     122.25 ns |     1.031 ns |     0.964 ns |         - |
| Decrypt · AES-256-GCM (Managed)      | 128B         |     608.48 ns |     4.136 ns |     3.667 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle) | 128B         |   1,056.48 ns |     6.038 ns |     5.648 ns |    1832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-GCM (AES-NI)       | 128B         |      81.96 ns |     0.232 ns |     0.217 ns |         - |
| Encrypt · AES-256-GCM (OS)           | 128B         |     124.49 ns |     1.229 ns |     1.089 ns |         - |
| Encrypt · AES-256-GCM (Managed)      | 128B         |     574.98 ns |     4.205 ns |     3.728 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle) | 128B         |     984.79 ns |    15.708 ns |    14.694 ns |    1816 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)           | 1KB          |     208.45 ns |     1.252 ns |     1.110 ns |         - |
| Decrypt · AES-256-GCM (AES-NI)       | 1KB          |     310.47 ns |     2.419 ns |     2.263 ns |         - |
| Decrypt · AES-256-GCM (Managed)      | 1KB          |   3,988.82 ns |    31.830 ns |    28.217 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle) | 1KB          |   4,701.10 ns |    30.881 ns |    28.887 ns |    1832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)           | 1KB          |     181.95 ns |     0.734 ns |     0.651 ns |         - |
| Encrypt · AES-256-GCM (AES-NI)       | 1KB          |     317.12 ns |     1.998 ns |     1.771 ns |         - |
| Encrypt · AES-256-GCM (Managed)      | 1KB          |   3,975.47 ns |    39.279 ns |    36.742 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle) | 1KB          |   4,620.87 ns |    27.902 ns |    23.300 ns |    1816 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)           | 8KB          |     920.88 ns |     3.801 ns |     3.555 ns |         - |
| Decrypt · AES-256-GCM (AES-NI)       | 8KB          |   1,952.62 ns |    15.725 ns |    14.709 ns |         - |
| Decrypt · AES-256-GCM (Managed)      | 8KB          |  30,839.10 ns |   132.977 ns |   117.881 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle) | 8KB          |  33,936.86 ns |   260.607 ns |   231.021 ns |    1832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)           | 8KB          |     709.93 ns |     4.476 ns |     4.187 ns |         - |
| Encrypt · AES-256-GCM (AES-NI)       | 8KB          |   2,213.76 ns |    11.468 ns |    10.728 ns |         - |
| Encrypt · AES-256-GCM (Managed)      | 8KB          |  30,841.76 ns |   195.356 ns |   182.736 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle) | 8KB          |  33,697.12 ns |   227.581 ns |   201.745 ns |    1816 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)           | 128KB        |  15,931.92 ns |   237.778 ns |   222.418 ns |         - |
| Decrypt · AES-256-GCM (AES-NI)       | 128KB        |  30,667.55 ns |   209.069 ns |   195.563 ns |         - |
| Decrypt · AES-256-GCM (Managed)      | 128KB        | 491,397.39 ns | 1,711.555 ns | 1,600.989 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle) | 128KB        | 530,733.53 ns | 3,803.174 ns | 3,557.491 ns |    1832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)           | 128KB        |  10,687.03 ns |   175.924 ns |   164.559 ns |         - |
| Encrypt · AES-256-GCM (AES-NI)       | 128KB        |  34,644.94 ns |   232.925 ns |   217.878 ns |         - |
| Encrypt · AES-256-GCM (Managed)      | 128KB        | 493,137.65 ns | 3,912.130 ns | 3,659.409 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle) | 128KB        | 528,050.86 ns | 3,597.703 ns | 3,365.294 ns |    1816 B |