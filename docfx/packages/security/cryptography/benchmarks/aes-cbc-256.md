| Description                          | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CBC (AES-NI)       | 128B         |      22.69 ns |     0.044 ns |     0.037 ns |         - |
| Decrypt · AES-256-CBC (OS)           | 128B         |     261.33 ns |     0.809 ns |     0.717 ns |     128 B |
| Decrypt · AES-256-CBC (Managed)      | 128B         |     566.01 ns |    10.516 ns |     8.781 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 128B         |     892.09 ns |     3.796 ns |     3.551 ns |    1024 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-CBC (AES-NI)       | 128B         |     167.26 ns |     0.288 ns |     0.255 ns |         - |
| Encrypt · AES-256-CBC (OS)           | 128B         |     312.81 ns |     1.112 ns |     0.986 ns |     128 B |
| Encrypt · AES-256-CBC (Managed)      | 128B         |     501.36 ns |     0.988 ns |     0.771 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 128B         |     803.13 ns |     1.975 ns |     1.649 ns |    1024 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-256-CBC (AES-NI)       | 1KB          |      98.46 ns |     0.145 ns |     0.129 ns |         - |
| Decrypt · AES-256-CBC (OS)           | 1KB          |     332.98 ns |     0.737 ns |     0.689 ns |     128 B |
| Decrypt · AES-256-CBC (Managed)      | 1KB          |   4,022.63 ns |    15.366 ns |    14.374 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 1KB          |   4,903.39 ns |    15.933 ns |    14.124 ns |    1024 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)           | 1KB          |     898.37 ns |     1.420 ns |     1.258 ns |     128 B |
| Encrypt · AES-256-CBC (AES-NI)       | 1KB          |   1,320.31 ns |     2.410 ns |     2.012 ns |         - |
| Encrypt · AES-256-CBC (Managed)      | 1KB          |   3,982.52 ns |     7.150 ns |     6.339 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 1KB          |   4,803.22 ns |    10.146 ns |     8.994 ns |    1024 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-256-CBC (AES-NI)       | 8KB          |     707.33 ns |     3.060 ns |     2.555 ns |         - |
| Decrypt · AES-256-CBC (OS)           | 8KB          |     940.73 ns |     0.939 ns |     0.832 ns |     128 B |
| Decrypt · AES-256-CBC (Managed)      | 8KB          |  31,692.93 ns |   141.180 ns |   117.891 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 8KB          |  36,576.46 ns |    83.176 ns |    77.803 ns |    1024 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)           | 8KB          |   5,713.87 ns |    94.973 ns |    88.838 ns |     128 B |
| Encrypt · AES-256-CBC (AES-NI)       | 8KB          |  10,502.83 ns |    18.114 ns |    16.944 ns |         - |
| Encrypt · AES-256-CBC (Managed)      | 8KB          |  31,945.28 ns |   252.094 ns |   196.819 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 8KB          |  36,866.44 ns |   118.872 ns |    99.264 ns |    1024 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-256-CBC (AES-NI)       | 128KB        |  11,440.06 ns |    46.121 ns |    38.513 ns |         - |
| Decrypt · AES-256-CBC (OS)           | 128KB        |  11,449.14 ns |    13.272 ns |    11.765 ns |     128 B |
| Decrypt · AES-256-CBC (Managed)      | 128KB        | 504,382.08 ns | 1,438.682 ns | 1,201.365 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 128KB        | 579,951.99 ns | 2,796.735 ns | 2,183.507 ns |    1024 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)           | 128KB        |  91,321.69 ns |   183.646 ns |   171.783 ns |     128 B |
| Encrypt · AES-256-CBC (AES-NI)       | 128KB        | 168,634.98 ns |   165.761 ns |   138.418 ns |         - |
| Encrypt · AES-256-CBC (Managed)      | 128KB        | 510,070.03 ns | 2,948.544 ns | 2,462.168 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 128KB        | 584,549.28 ns |   973.945 ns |   813.288 ns |    1024 B |