| Description                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-128-CBC (AES-NI)       | 128B         |     120.3 ns |     1.18 ns |     1.10 ns |         - |
| Decrypt · AES-128-CBC (OS)           | 128B         |     242.0 ns |     1.60 ns |     1.50 ns |     128 B |
| Decrypt · AES-128-CBC (Managed)      | 128B         |     437.4 ns |     3.03 ns |     2.69 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 128B         |     702.6 ns |     4.44 ns |     3.94 ns |     832 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CBC (AES-NI)       | 128B         |     158.5 ns |     1.96 ns |     1.53 ns |         - |
| Encrypt · AES-128-CBC (OS)           | 128B         |     278.9 ns |     0.96 ns |     0.80 ns |     128 B |
| Encrypt · AES-128-CBC (Managed)      | 128B         |     401.0 ns |     2.44 ns |     2.16 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 128B         |     623.4 ns |     2.79 ns |     2.61 ns |     832 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CBC (OS)           | 1KB          |     301.6 ns |     2.38 ns |     2.23 ns |     128 B |
| Decrypt · AES-128-CBC (AES-NI)       | 1KB          |     801.1 ns |     4.19 ns |     3.50 ns |         - |
| Decrypt · AES-128-CBC (Managed)      | 1KB          |   3,101.5 ns |    16.78 ns |    15.69 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 1KB          |   3,852.3 ns |    20.44 ns |    18.12 ns |     832 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CBC (OS)           | 1KB          |     697.9 ns |     1.99 ns |     1.86 ns |     128 B |
| Encrypt · AES-128-CBC (AES-NI)       | 1KB          |   1,250.9 ns |     2.93 ns |     2.74 ns |         - |
| Encrypt · AES-128-CBC (Managed)      | 1KB          |   3,131.8 ns |    17.20 ns |    14.37 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 1KB          |   3,703.2 ns |    20.47 ns |    18.15 ns |     832 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CBC (OS)           | 8KB          |     733.9 ns |     1.86 ns |     1.65 ns |     128 B |
| Decrypt · AES-128-CBC (AES-NI)       | 8KB          |   6,246.4 ns |    26.58 ns |    23.56 ns |         - |
| Decrypt · AES-128-CBC (Managed)      | 8KB          |  24,415.5 ns |    96.56 ns |    80.63 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 8KB          |  28,918.2 ns |   187.48 ns |   175.37 ns |     832 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CBC (OS)           | 8KB          |   4,266.8 ns |    27.68 ns |    25.89 ns |     128 B |
| Encrypt · AES-128-CBC (AES-NI)       | 8KB          |  10,003.0 ns |    26.27 ns |    24.57 ns |         - |
| Encrypt · AES-128-CBC (Managed)      | 8KB          |  25,085.7 ns |    99.80 ns |    88.47 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 8KB          |  28,277.5 ns |    77.31 ns |    68.53 ns |     832 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CBC (OS)           | 128KB        |   8,128.0 ns |    42.58 ns |    37.74 ns |     128 B |
| Decrypt · AES-128-CBC (AES-NI)       | 128KB        |  99,516.1 ns |   653.93 ns |   579.69 ns |         - |
| Decrypt · AES-128-CBC (Managed)      | 128KB        | 390,789.4 ns | 1,903.59 ns | 1,589.58 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 128KB        | 460,661.5 ns | 2,697.89 ns | 2,523.61 ns |     832 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CBC (OS)           | 128KB        |  65,666.4 ns |   248.61 ns |   232.55 ns |     128 B |
| Encrypt · AES-128-CBC (AES-NI)       | 128KB        | 158,473.2 ns |   364.59 ns |   323.20 ns |         - |
| Encrypt · AES-128-CBC (Managed)      | 128KB        | 399,318.3 ns | 6,020.47 ns | 5,027.36 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 128KB        | 451,186.6 ns | 4,023.94 ns | 3,763.99 ns |     832 B |