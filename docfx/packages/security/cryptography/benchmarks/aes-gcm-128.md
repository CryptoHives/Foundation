| Description                          | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-GCM (AES-NI)       | 128B         |     103.01 ns |     2.086 ns |     3.185 ns |         - |
| Decrypt · AES-128-GCM (OS)           | 128B         |     119.06 ns |     2.159 ns |     1.803 ns |         - |
| Decrypt · AES-128-GCM (Managed)      | 128B         |     494.15 ns |     7.821 ns |    10.170 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle) | 128B         |     893.62 ns |    13.674 ns |    11.419 ns |    1624 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-128-GCM (AES-NI)       | 128B         |      73.12 ns |     1.231 ns |     1.028 ns |         - |
| Encrypt · AES-128-GCM (OS)           | 128B         |     119.65 ns |     1.626 ns |     1.269 ns |         - |
| Encrypt · AES-128-GCM (Managed)      | 128B         |     454.28 ns |     3.324 ns |     3.109 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle) | 128B         |     795.06 ns |     9.138 ns |     7.631 ns |    1608 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)           | 1KB          |     177.02 ns |     0.965 ns |     0.806 ns |         - |
| Decrypt · AES-128-GCM (AES-NI)       | 1KB          |     269.29 ns |     2.865 ns |     2.540 ns |         - |
| Decrypt · AES-128-GCM (Managed)      | 1KB          |   3,137.43 ns |    20.712 ns |    18.361 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle) | 1KB          |   3,660.12 ns |    18.089 ns |    16.920 ns |    1624 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)           | 1KB          |     171.88 ns |     0.978 ns |     0.817 ns |         - |
| Encrypt · AES-128-GCM (AES-NI)       | 1KB          |     271.12 ns |     2.437 ns |     2.160 ns |         - |
| Encrypt · AES-128-GCM (Managed)      | 1KB          |   3,097.79 ns |    20.036 ns |    17.761 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle) | 1KB          |   3,600.46 ns |    52.284 ns |    43.659 ns |    1608 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)           | 8KB          |     685.35 ns |    13.398 ns |    12.532 ns |         - |
| Decrypt · AES-128-GCM (AES-NI)       | 8KB          |   1,661.98 ns |    24.306 ns |    22.736 ns |         - |
| Decrypt · AES-128-GCM (Managed)      | 8KB          |  24,543.01 ns |   394.730 ns |   349.918 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle) | 8KB          |  25,678.99 ns |   191.600 ns |   149.589 ns |    1624 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)           | 8KB          |     665.71 ns |     9.539 ns |     8.456 ns |         - |
| Encrypt · AES-128-GCM (AES-NI)       | 8KB          |   1,857.76 ns |    24.459 ns |    20.425 ns |         - |
| Encrypt · AES-128-GCM (Managed)      | 8KB          |  24,755.52 ns |   439.304 ns |   615.843 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle) | 8KB          |  25,964.74 ns |   198.015 ns |   154.597 ns |    1608 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)           | 128KB        |  10,804.03 ns |    54.607 ns |    48.408 ns |         - |
| Decrypt · AES-128-GCM (AES-NI)       | 128KB        |  26,016.72 ns |   503.117 ns |   420.125 ns |         - |
| Decrypt · AES-128-GCM (Managed)      | 128KB        | 385,936.47 ns | 1,680.175 ns | 1,489.431 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle) | 128KB        | 404,923.63 ns | 1,833.942 ns | 1,625.741 ns |    1624 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)           | 128KB        |  10,347.02 ns |   201.225 ns |   215.308 ns |         - |
| Encrypt · AES-128-GCM (AES-NI)       | 128KB        |  28,988.72 ns |   163.866 ns |   145.263 ns |         - |
| Encrypt · AES-128-GCM (Managed)      | 128KB        | 389,242.35 ns | 5,556.949 ns | 4,926.090 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle) | 128KB        | 409,971.90 ns | 7,791.298 ns | 8,660.007 ns |    1608 B |