| Description                          | TestDataSize | Mean          | Error        | StdDev       | Median        | Allocated |
|------------------------------------- |------------- |--------------:|-------------:|-------------:|--------------:|----------:|
| Decrypt · AES-128-CBC (AES-NI)       | 128B         |      29.90 ns |     0.382 ns |     0.358 ns |      29.78 ns |         - |
| Decrypt · AES-128-CBC (OS)           | 128B         |     246.44 ns |     2.508 ns |     2.346 ns |     246.90 ns |     128 B |
| Decrypt · AES-128-CBC (Managed)      | 128B         |     439.76 ns |     2.413 ns |     2.257 ns |     439.81 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 128B         |     692.44 ns |     4.885 ns |     4.570 ns |     690.71 ns |     832 B |
|                                      |              |               |              |              |               |           |
| Encrypt · AES-128-CBC (AES-NI)       | 128B         |     171.33 ns |     3.327 ns |     3.112 ns |     171.54 ns |         - |
| Encrypt · AES-128-CBC (OS)           | 128B         |     274.43 ns |     2.993 ns |     2.800 ns |     274.02 ns |     128 B |
| Encrypt · AES-128-CBC (Managed)      | 128B         |     445.61 ns |     2.419 ns |     2.020 ns |     445.70 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 128B         |     636.11 ns |     1.403 ns |     1.096 ns |     635.65 ns |     832 B |
|                                      |              |               |              |              |               |           |
| Decrypt · AES-128-CBC (AES-NI)       | 1KB          |      89.56 ns |     1.163 ns |     1.087 ns |      88.75 ns |         - |
| Decrypt · AES-128-CBC (OS)           | 1KB          |     303.75 ns |     1.647 ns |     1.460 ns |     303.25 ns |     128 B |
| Decrypt · AES-128-CBC (Managed)      | 1KB          |   3,111.00 ns |    31.577 ns |    29.537 ns |   3,102.28 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 1KB          |   3,895.86 ns |    31.179 ns |    29.165 ns |   3,884.31 ns |     832 B |
|                                      |              |               |              |              |               |           |
| Encrypt · AES-128-CBC (OS)           | 1KB          |     698.81 ns |     3.463 ns |     3.070 ns |     697.70 ns |     128 B |
| Encrypt · AES-128-CBC (AES-NI)       | 1KB          |   1,175.13 ns |     5.550 ns |     5.192 ns |   1,174.18 ns |         - |
| Encrypt · AES-128-CBC (Managed)      | 1KB          |   3,120.67 ns |    23.789 ns |    21.088 ns |   3,119.42 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 1KB          |   3,725.55 ns |    27.872 ns |    26.072 ns |   3,724.62 ns |     832 B |
|                                      |              |               |              |              |               |           |
| Decrypt · AES-128-CBC (AES-NI)       | 8KB          |     568.19 ns |     2.719 ns |     2.543 ns |     566.98 ns |         - |
| Decrypt · AES-128-CBC (OS)           | 8KB          |     732.64 ns |     4.745 ns |     4.207 ns |     733.30 ns |     128 B |
| Decrypt · AES-128-CBC (Managed)      | 8KB          |  24,283.63 ns |   122.578 ns |   108.662 ns |  24,280.46 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 8KB          |  29,166.53 ns |   261.978 ns |   245.054 ns |  29,099.30 ns |     832 B |
|                                      |              |               |              |              |               |           |
| Encrypt · AES-128-CBC (OS)           | 8KB          |   4,278.31 ns |    53.715 ns |    50.245 ns |   4,266.29 ns |     128 B |
| Encrypt · AES-128-CBC (AES-NI)       | 8KB          |   9,100.45 ns |    64.454 ns |    60.290 ns |   9,084.92 ns |         - |
| Encrypt · AES-128-CBC (Managed)      | 8KB          |  24,549.96 ns |   159.960 ns |   149.627 ns |  24,565.28 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 8KB          |  29,835.58 ns |   592.595 ns | 1,419.820 ns |  29,307.96 ns |     832 B |
|                                      |              |               |              |              |               |           |
| Decrypt · AES-128-CBC (OS)           | 128KB        |   8,302.64 ns |    55.443 ns |    51.861 ns |   8,291.44 ns |     128 B |
| Decrypt · AES-128-CBC (AES-NI)       | 128KB        |   8,849.10 ns |    89.091 ns |    83.335 ns |   8,857.57 ns |         - |
| Decrypt · AES-128-CBC (Managed)      | 128KB        | 391,412.22 ns | 3,635.462 ns | 3,400.614 ns | 390,479.98 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 128KB        | 461,918.15 ns | 2,776.376 ns | 2,597.024 ns | 461,417.43 ns |     832 B |
|                                      |              |               |              |              |               |           |
| Encrypt · AES-128-CBC (OS)           | 128KB        |  65,933.87 ns |   421.309 ns |   373.479 ns |  65,859.27 ns |     128 B |
| Encrypt · AES-128-CBC (AES-NI)       | 128KB        | 144,081.35 ns |   590.215 ns |   523.210 ns | 143,899.71 ns |         - |
| Encrypt · AES-128-CBC (Managed)      | 128KB        | 391,274.38 ns | 4,268.993 ns | 3,993.219 ns | 389,712.01 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 128KB        | 451,990.97 ns | 3,184.885 ns | 2,486.549 ns | 452,597.80 ns |     832 B |