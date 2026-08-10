| Description                          | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CCM (AES-NI)       | 128B         |       467.5 ns |      8.07 ns |      7.55 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 128B         |     1,326.8 ns |     26.38 ns |     30.38 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 128B         |     2,060.4 ns |     39.57 ns |     43.98 ns |    2808 B |
|                                      |              |                |              |              |           |
| Encrypt · AES-256-CCM (AES-NI)       | 128B         |       417.3 ns |      1.93 ns |      1.71 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 128B         |     1,261.1 ns |     24.02 ns |     22.46 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 128B         |     2,004.8 ns |     39.52 ns |     49.98 ns |    2848 B |
|                                      |              |                |              |              |           |
| Decrypt · AES-256-CCM (AES-NI)       | 1KB          |     2,776.7 ns |     20.53 ns |     18.20 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 1KB          |     8,345.9 ns |    162.67 ns |    174.05 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 1KB          |    10,585.1 ns |    166.52 ns |    147.62 ns |    2808 B |
|                                      |              |                |              |              |           |
| Encrypt · AES-256-CCM (AES-NI)       | 1KB          |     2,720.7 ns |     13.93 ns |     11.63 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 1KB          |     8,210.2 ns |    114.21 ns |    106.83 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 1KB          |    10,394.9 ns |    174.70 ns |    163.42 ns |    2848 B |
|                                      |              |                |              |              |           |
| Decrypt · AES-256-CCM (AES-NI)       | 8KB          |    21,330.9 ns |    157.67 ns |    147.48 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 8KB          |    65,207.4 ns |  1,222.22 ns |  1,255.13 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 8KB          |    77,823.1 ns |  1,401.36 ns |  1,242.27 ns |    2808 B |
|                                      |              |                |              |              |           |
| Encrypt · AES-256-CCM (AES-NI)       | 8KB          |    21,248.8 ns |    174.90 ns |    155.05 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 8KB          |    63,817.0 ns |  1,070.73 ns |  1,001.56 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 8KB          |    76,987.2 ns |    609.28 ns |    540.11 ns |    2848 B |
|                                      |              |                |              |              |           |
| Decrypt · AES-256-CCM (AES-NI)       | 128KB        |   342,165.1 ns |  3,636.03 ns |  3,223.24 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 128KB        | 1,059,863.7 ns | 20,816.37 ns | 27,789.26 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 128KB        | 1,282,798.0 ns | 20,611.13 ns | 19,279.66 ns |    2808 B |
|                                      |              |                |              |              |           |
| Encrypt · AES-256-CCM (AES-NI)       | 128KB        |   337,517.7 ns |    891.37 ns |    790.17 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 128KB        | 1,025,434.3 ns | 15,957.64 ns | 14,926.79 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 128KB        | 1,223,135.7 ns | 17,115.83 ns | 15,172.74 ns |    2848 B |