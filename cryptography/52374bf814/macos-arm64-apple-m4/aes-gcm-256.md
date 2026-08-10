| Description                             | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|---------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-GCM (ArmAes+ArmPmull) | 17B          |      85.36 ns |     0.119 ns |     0.112 ns |         - |
| Decrypt · AES-256-GCM (Managed)         | 17B          |     390.48 ns |     0.448 ns |     0.397 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)    | 17B          |     663.59 ns |     0.935 ns |     0.875 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)              | 17B          |   1,922.85 ns |     9.287 ns |     8.687 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · AES-256-GCM (ArmAes+ArmPmull) | 17B          |      55.83 ns |     0.110 ns |     0.098 ns |         - |
| Encrypt · AES-256-GCM (Managed)         | 17B          |     360.85 ns |     0.454 ns |     0.379 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)    | 17B          |     591.05 ns |     3.246 ns |     2.711 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)              | 17B          |   1,755.88 ns |     7.393 ns |     6.915 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · AES-256-GCM (ArmAes+ArmPmull) | 65B          |     119.10 ns |     0.537 ns |     0.503 ns |         - |
| Decrypt · AES-256-GCM (Managed)         | 65B          |     701.72 ns |     0.245 ns |     0.217 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)    | 65B          |     902.60 ns |     1.008 ns |     0.943 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)              | 65B          |   1,915.24 ns |    11.849 ns |    11.083 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · AES-256-GCM (ArmAes+ArmPmull) | 65B          |      86.45 ns |     0.318 ns |     0.298 ns |         - |
| Encrypt · AES-256-GCM (Managed)         | 65B          |     663.52 ns |     0.391 ns |     0.305 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)    | 65B          |     843.46 ns |     1.208 ns |     1.009 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)              | 65B          |   1,748.38 ns |     3.972 ns |     3.317 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · AES-256-GCM (ArmAes+ArmPmull) | 128B         |     154.90 ns |     1.016 ns |     0.950 ns |         - |
| Decrypt · AES-256-GCM (Managed)         | 128B         |   1,001.89 ns |     0.404 ns |     0.378 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)    | 128B         |   1,153.02 ns |     0.897 ns |     0.839 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)              | 128B         |   1,935.36 ns |    11.800 ns |    11.038 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · AES-256-GCM (ArmAes+ArmPmull) | 128B         |     122.88 ns |     0.824 ns |     0.730 ns |         - |
| Encrypt · AES-256-GCM (Managed)         | 128B         |     965.58 ns |     0.905 ns |     0.707 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)    | 128B         |   1,105.18 ns |     1.522 ns |     1.271 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)              | 128B         |   1,765.75 ns |     6.769 ns |     6.001 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · AES-256-GCM (ArmAes+ArmPmull) | 152B         |     185.18 ns |     1.329 ns |     1.179 ns |         - |
| Decrypt · AES-256-GCM (Managed)         | 152B         |   1,206.84 ns |     0.975 ns |     0.912 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)    | 152B         |   1,308.12 ns |     1.040 ns |     0.973 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)              | 152B         |   1,940.98 ns |    15.149 ns |    14.171 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · AES-256-GCM (ArmAes+ArmPmull) | 152B         |     150.99 ns |     0.686 ns |     0.642 ns |         - |
| Encrypt · AES-256-GCM (Managed)         | 152B         |   1,169.38 ns |     0.932 ns |     0.871 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)    | 152B         |   1,267.30 ns |     1.184 ns |     1.107 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)              | 152B         |   1,775.11 ns |    10.951 ns |     9.708 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · AES-256-GCM (ArmAes+ArmPmull) | 256B         |     251.56 ns |     1.575 ns |     1.473 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)    | 256B         |   1,781.33 ns |     0.660 ns |     0.618 ns |    1744 B |
| Decrypt · AES-256-GCM (Managed)         | 256B         |   1,819.14 ns |     0.465 ns |     0.435 ns |         - |
| Decrypt · AES-256-GCM (OS)              | 256B         |   1,927.66 ns |    10.525 ns |     8.789 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · AES-256-GCM (ArmAes+ArmPmull) | 256B         |     221.30 ns |     0.766 ns |     0.716 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)    | 256B         |   1,767.94 ns |     0.785 ns |     0.735 ns |    1728 B |
| Encrypt · AES-256-GCM (Managed)         | 256B         |   1,780.59 ns |     0.407 ns |     0.361 ns |         - |
| Encrypt · AES-256-GCM (OS)              | 256B         |   1,786.94 ns |     8.376 ns |     7.835 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · AES-256-GCM (ArmAes+ArmPmull) | 1KB          |     821.40 ns |     4.078 ns |     3.615 ns |         - |
| Decrypt · AES-256-GCM (OS)              | 1KB          |   2,066.99 ns |    13.375 ns |    12.511 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)    | 1KB          |   5,529.15 ns |     1.817 ns |     1.700 ns |    1744 B |
| Decrypt · AES-256-GCM (Managed)         | 1KB          |   6,580.74 ns |     2.554 ns |     2.264 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · AES-256-GCM (ArmAes+ArmPmull) | 1KB          |     798.05 ns |     4.140 ns |     3.873 ns |         - |
| Encrypt · AES-256-GCM (OS)              | 1KB          |   1,899.13 ns |    17.089 ns |    15.985 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)    | 1KB          |   5,748.85 ns |     1.430 ns |     1.338 ns |    1728 B |
| Encrypt · AES-256-GCM (Managed)         | 1KB          |   6,458.19 ns |     1.358 ns |     1.270 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)              | 8KB          |   3,085.76 ns |    25.035 ns |    23.417 ns |         - |
| Decrypt · AES-256-GCM (ArmAes+ArmPmull) | 8KB          |   6,200.93 ns |     5.322 ns |     4.718 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)    | 8KB          |  39,942.50 ns |    28.876 ns |    27.010 ns |    1744 B |
| Decrypt · AES-256-GCM (Managed)         | 8KB          |  50,698.65 ns |    35.145 ns |    29.347 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)              | 8KB          |   2,974.20 ns |    11.999 ns |    11.224 ns |         - |
| Encrypt · AES-256-GCM (ArmAes+ArmPmull) | 8KB          |   6,201.55 ns |    15.969 ns |    14.156 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)    | 8KB          |  42,596.76 ns |    13.218 ns |    12.364 ns |    1728 B |
| Encrypt · AES-256-GCM (Managed)         | 8KB          |  50,671.48 ns |    26.373 ns |    24.670 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)              | 128KB        |  22,147.61 ns |    96.588 ns |    90.349 ns |         - |
| Decrypt · AES-256-GCM (ArmAes+ArmPmull) | 128KB        |  98,473.75 ns |   154.333 ns |   120.493 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)    | 128KB        | 631,948.75 ns |   279.856 ns |   261.777 ns |    1744 B |
| Decrypt · AES-256-GCM (Managed)         | 128KB        | 808,117.93 ns |   135.905 ns |   120.477 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)              | 128KB        |  22,816.94 ns |    86.248 ns |    80.676 ns |         - |
| Encrypt · AES-256-GCM (ArmAes+ArmPmull) | 128KB        |  99,847.51 ns | 1,357.781 ns | 1,270.069 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)    | 128KB        | 672,293.47 ns |   362.406 ns |   302.626 ns |    1728 B |
| Encrypt · AES-256-GCM (Managed)         | 128KB        | 806,702.94 ns |   324.443 ns |   287.610 ns |         - |