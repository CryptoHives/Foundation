| Description                          | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-CCM (Managed)      | 128B         |     1,030.2 ns |     14.26 ns |     11.91 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 128B         |     1,649.8 ns |     17.83 ns |     16.67 ns |    2888 B |
|                                      |              |                |              |              |           |
| Encrypt · AES-128-CCM (Managed)      | 128B         |       989.8 ns |     10.24 ns |      9.58 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 128B         |     1,624.1 ns |     17.30 ns |     16.18 ns |    2928 B |
|                                      |              |                |              |              |           |
| Decrypt · AES-128-CCM (Managed)      | 1KB          |     6,504.9 ns |     38.54 ns |     34.16 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 1KB          |     8,193.1 ns |     63.75 ns |     59.63 ns |    4680 B |
|                                      |              |                |              |              |           |
| Encrypt · AES-128-CCM (Managed)      | 1KB          |     6,463.8 ns |     49.35 ns |     46.16 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 1KB          |     8,178.0 ns |     98.27 ns |     91.92 ns |    4720 B |
|                                      |              |                |              |              |           |
| Decrypt · AES-128-CCM (Managed)      | 8KB          |    50,214.5 ns |    391.29 ns |    366.01 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 8KB          |    60,149.3 ns |    270.58 ns |    253.11 ns |   19016 B |
|                                      |              |                |              |              |           |
| Encrypt · AES-128-CCM (Managed)      | 8KB          |    50,308.3 ns |    369.15 ns |    345.30 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 8KB          |    60,019.1 ns |    651.03 ns |    608.97 ns |   19056 B |
|                                      |              |                |              |              |           |
| Decrypt · AES-128-CCM (Managed)      | 128KB        |   800,807.4 ns |  7,255.33 ns |  6,786.64 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 128KB        |   996,138.6 ns | 14,034.08 ns | 13,127.49 ns |  264804 B |
|                                      |              |                |              |              |           |
| Encrypt · AES-128-CCM (Managed)      | 128KB        |   799,726.0 ns |  6,926.97 ns |  6,479.49 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 128KB        | 1,002,382.4 ns | 12,464.76 ns | 11,659.54 ns |  264844 B |